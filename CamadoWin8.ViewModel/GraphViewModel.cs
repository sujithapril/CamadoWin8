using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using CamadoWin8.Contracts.Model;
using CamadoWin8.Contracts.Services;
using CamadoWin8.Contracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadoWin8.Shared;
using System.Collections.ObjectModel;


namespace CamadoWin8.ViewModel
{
    public class GraphViewModel : ViewModelBase, IGraphViewModel
    {
        public RelayCommand GoBack { get; set; }
        public RelayCommand GoHome { get; set; }
        public RelayCommand AddToFavorites { get; set; }


        public INavigationService navigationService;
        private IDialogService dialogService;
        private IShareContractService shareContractService;
        private ITileService tileService;
        private IToastService toastService;
        private IStateService stateService;
        private IGraphService graphService;

        private IDeviceInfo deviceObj;
        /* public struct barDataModel
         {
             public string key;
             public Double value;
         }*/
        public struct barDataModel
        {
            public DateTime Key;
            public float Frequency;
            public float Humidity;
            public float Spl;
            public float Temprature;
            public float Vib;
        }
        public List<String> Columns = new List<string>();
        public List<barDataModel> BarData = new List<barDataModel>();

        public float getMaxFrequency()
        {
            return this.BarData.OfType<barDataModel>().Max(barDataModel => barDataModel.Frequency);
        }
        public float getMaxHumidity()
        {
            return this.BarData.Max(barDataModel => barDataModel.Humidity);
        }
        public float getMaxspl()
        {
            return this.BarData.Max(barDataModel => barDataModel.Spl);
        }
        public float getMaxTemprature()
        {
            return this.BarData.Max(barDataModel => barDataModel.Temprature);
        }
        public float getMaxVib()
        {
            return this.BarData.Max(barDataModel => barDataModel.Vib);
        }
        private ObservableCollection<IDeviceInfo> deviceTileInfos;

        public ObservableCollection<IDeviceInfo> DeviceTileInfos
        {
            get
            {
                return deviceTileInfos;
            }
            set
            {
                deviceTileInfos = value;
                RaisePropertyChanged("DeviceTileInfos");
            }
        }

        //private List<IDeviceInfo> deviceTileInfos;

        //public List<IDeviceInfo> DeviceTileInfos
        //{
        //    get
        //    {
        //        return deviceTileInfos;
        //    }
        //    set
        //    {
        //        deviceTileInfos = value;
        //        RaisePropertyChanged("DeviceTileInfos");
        //    }
        //}
        public RelayCommand<IDeviceInfo> SelectedCommand { get; set; }
        public GraphViewModel(INavigationService navigationService, IDialogService dialogService, IShareContractService shareContractService,
            ITileService tileService, IToastService toastService, IStateService stateService, IGraphService graphService)
        {

            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.shareContractService = shareContractService;
            this.tileService = tileService;
            this.toastService = toastService;
            this.stateService = stateService;
            this.graphService = graphService;
            InitializeCommands();

        }

        private void InitializeCommands()
        {

            GoBack = new RelayCommand(() =>
            {
                navigationService.GoBack();
            });
            //GoHome = new RelayCommand(() =>
            //{
            //    navigationService.Navigate(PageNames.PopularTravelView);
            //});
            //AddToFavorites = new RelayCommand(() => 
            //{
            //    dialogService.ShowAddToFavoriteConfirmation();
            //});
        }
        public void LoadDetailView(DateTime selectedDate, PageNames.BarType parameter)
        {
            var passedObj = new Tuple<IDeviceInfo, PageNames.BarType>(deviceObj,parameter);
            deviceObj.StartDate = BarData[0].Key;
            DateTime endDate = (BarData[0].Key).AddHours(1);
            deviceObj.EndDate = endDate;
            navigationService.Navigate(PageNames.DetailGraphView, passedObj);

        }

        public async void Initialize(object parameter)
        {

            deviceObj = parameter as IDeviceInfo;
            
            RootObject barGraphdata = null;
            if (!await ApplicationVariables.IsOnLine())
            {
                barGraphdata = (RootObject)await graphService.GetBarGraph(deviceObj.DeviceId.ToString(), deviceObj.DeviceMacId);
            }
            else
            {
                barGraphdata = (RootObject)await graphService.GetBarGraph2(deviceObj.DeviceId.ToString(), deviceObj.DeviceMacId);
            }

           
            this.BarData.Clear();
            if (barGraphdata.allGraphData != null)
            {
                foreach (GraphResult result in barGraphdata.allGraphData.graphData.graphResults)
                {
                    if (result.graphSeries != null)
                    {
                        foreach (GraphSery series in result.graphSeries)
                        {
                            if (series.values != null)
                            {
                                foreach (List<object> list in series.values)
                                {
                                    System.Diagnostics.Debug.WriteLine(list[0]);
                                    DateTime date = (DateTime)list[0];
                                    float frequency = Convert.ToSingle(list[1]);
                                    float temp = Convert.ToSingle(list[2]);
                                    float hum = Convert.ToSingle(list[3]);
                                    float sound = Convert.ToSingle(list[4]);
                                    float vib = Convert.ToSingle(list[5]);

                                    barDataModel datamodel = new barDataModel()
                                    {
                                        Frequency = frequency,
                                        Temprature = temp,
                                        Humidity = hum,
                                        Spl = sound,
                                        Vib = vib,
                                        Key = date
                                    };
                                    BarData.Add(datamodel);
                                }
                            }
                        }
                    }
                }
            }
            var LoadGraph = new LoadGroupedBarGraph { Message = "LoadGraph" };
            MessengerInstance.Send<LoadGroupedBarGraph>(LoadGraph);
            if(BarData.Count > 0)
            {
                deviceObj.StartDate = BarData[0].Key;
                DateTime endDate = (BarData[0].Key).AddHours(1);
                deviceObj.EndDate = endDate;
            }
            var passedObj = new Tuple<IDeviceInfo, PageNames.BarType>(deviceObj,PageNames.BarType.Frequency);

            navigationService.Navigate(PageNames.DetailGraphView, passedObj);

        }

    }
}
