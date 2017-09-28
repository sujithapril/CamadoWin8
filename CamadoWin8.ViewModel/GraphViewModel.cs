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


        private INavigationService navigationService;
        private IDialogService dialogService;
        private IShareContractService shareContractService;
        private ITileService tileService;
        private IToastService toastService;
        private IStateService stateService;
        private IGraphService graphService;

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

        /* public barDataModel[] frequencyData { get; set; } = new barDataModel[]
         {
             new barDataModel() {key = "2017-06-20T11:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T12:30:00Z", value = 3339.39f },
             new barDataModel() {key = "2017-06-20T13:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T14:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T15:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T16:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T17:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T18:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T19:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T20:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T21:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T22:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T23:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T00:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T01:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T02:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T03:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T04:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T05:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T06:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T07:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T08:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T09:30:00Z", value = 800.0f },
             new barDataModel() {key = "2017-06-20T10:30:00Z", value = 800.0f }

         };
         public barDataModel[] humidityData { get; set; } = new barDataModel[]
        {
             new barDataModel() {key = "2017-06-20T11:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T12:30:00Z", value = 44.0f },
             new barDataModel() {key = "2017-06-20T13:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T14:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T15:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T16:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T17:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T18:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T19:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T20:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T21:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T22:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T23:30:00Z", value = 10.0f },
             new barDataModel() {key = "2017-06-20T00:30:00Z", value = 60.0f },
             new barDataModel() {key = "2017-06-20T01:30:00Z", value = 40.0f },
             new barDataModel() {key = "2017-06-20T02:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T03:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T04:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T05:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T06:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T07:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T08:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T09:30:00Z", value = 25.0f },
             new barDataModel() {key = "2017-06-20T10:30:00Z", value = 25.0f }

        };
         public barDataModel[] splData { get; set; } = new barDataModel[]
        {
             new barDataModel() {key = "2017-06-20T11:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T12:30:00Z", value = 24.59f },
             new barDataModel() {key = "2017-06-20T13:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T14:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T15:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T16:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T17:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T18:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T19:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T20:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T21:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T22:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T23:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T00:30:00Z", value = 150.0f },
             new barDataModel() {key = "2017-06-20T01:30:00Z", value = 5.0f },
             new barDataModel() {key = "2017-06-20T02:30:00Z", value = 150.0f },
             new barDataModel() {key = "2017-06-20T03:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T04:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T05:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T06:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T07:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T08:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T09:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T10:30:00Z", value = 80.0f }

        };
         public barDataModel[] temperatureData { get; set; } = new barDataModel[]
        {
             new barDataModel() {key = "2017-06-20T11:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T12:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T13:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T14:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T15:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T16:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T17:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T18:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T19:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T20:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T21:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T22:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T23:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T00:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T01:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T02:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T03:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T04:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T05:30:00Z", value = 30.0f },
             new barDataModel() {key = "2017-06-20T06:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T07:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T08:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T09:30:00Z", value = 35.0f },
             new barDataModel() {key = "2017-06-20T10:30:00Z", value = 35.0f }

        };
         public barDataModel[] vibData { get; set; } = new barDataModel[]
      {
             new barDataModel() {key = "2017-06-20T11:30:00Z", value = 100.0f },
             new barDataModel() {key = "2017-06-20T12:30:00Z", value = 120.0f },
             new barDataModel() {key = "2017-06-20T13:30:00Z", value = 130.0f },
             new barDataModel() {key = "2017-06-20T14:30:00Z", value = 140.0f },
             new barDataModel() {key = "2017-06-20T15:30:00Z", value = 150.0f },
             new barDataModel() {key = "2017-06-20T16:30:00Z", value = 160.0f },
             new barDataModel() {key = "2017-06-20T17:30:00Z", value = 170.0f },
             new barDataModel() {key = "2017-06-20T18:30:00Z", value = 180.0f },
             new barDataModel() {key = "2017-06-20T19:30:00Z", value = 190.0f },
             new barDataModel() {key = "2017-06-20T20:30:00Z", value = 200.0f },
             new barDataModel() {key = "2017-06-20T21:30:00Z", value = 210.0f },
             new barDataModel() {key = "2017-06-20T22:30:00Z", value = 220.0f },
             new barDataModel() {key = "2017-06-20T23:30:00Z", value = 230.0f },
             new barDataModel() {key = "2017-06-20T00:30:00Z", value = 240.0f },
             new barDataModel() {key = "2017-06-20T01:30:00Z", value = 0.0f },
             new barDataModel() {key = "2017-06-20T02:30:00Z", value = 10.0f },
             new barDataModel() {key = "2017-06-20T03:30:00Z", value = 20.0f },
             new barDataModel() {key = "2017-06-20T04:30:00Z", value = 30.0f },
             new barDataModel() {key = "2017-06-20T05:30:00Z", value = 40.0f },
             new barDataModel() {key = "2017-06-20T06:30:00Z", value = 50.0f },
             new barDataModel() {key = "2017-06-20T07:30:00Z", value = 60.0f },
             new barDataModel() {key = "2017-06-20T08:30:00Z", value = 70.0f },
             new barDataModel() {key = "2017-06-20T09:30:00Z", value = 80.0f },
             new barDataModel() {key = "2017-06-20T10:30:00Z", value = 90.0f }

      };
      */

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
        public void LoadDetailView(PageNames.BarType parameter)
        {
            navigationService.Navigate(PageNames.DetailGraphView, parameter);

        }

        public async void Initialize(object parameter)
        {
            IDeviceInfo deviceObj = parameter as IDeviceInfo;
            RootObject barGraphdata = null;
            if (ApplicationVariables.IsOffLine == true)
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
                                    System.Diagnostics.Debug.WriteLine("List item => " + list[1]);
                                    System.Diagnostics.Debug.WriteLine("List item => " + list[2]);
                                    System.Diagnostics.Debug.WriteLine("List item => " + list[3]);
                                    System.Diagnostics.Debug.WriteLine("List item => " + list[4]);
                                    System.Diagnostics.Debug.WriteLine("List item => " + list[5]);
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
        }

    }
}
