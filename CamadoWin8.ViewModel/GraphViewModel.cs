using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using CamadoWin8.Contracts.Model;
using CamadoWin8.Contracts.Services;
using CamadoWin8.Contracts.ViewModels;
using CamadoWin8.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public struct barDataModel
        {
            public string key;
            public float value;
        }


        public barDataModel[] frequencyData { get; set; } = new barDataModel[]
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


        public float getMaxFrequency()
        {
            return this.frequencyData.OfType<barDataModel>().Max(barDataModel => barDataModel.value);
        }
        public float getFrequncyForValue(string value)
        {
            barDataModel obj = Array.Find(frequencyData, barDataModel => barDataModel.key == value);
            return obj.value;
        }
        public float getHumidityForValue(string value)
        {
            barDataModel obj = Array.Find(humidityData, barDataModel => barDataModel.key == value);
            return obj.value;
        }
        public float getSplForValue(string value)
        {
            barDataModel obj = Array.Find(splData, barDataModel => barDataModel.key == value);
            return obj.value;
        }
        public float getTemperatureForValue(string value)
        {
            barDataModel obj = Array.Find(temperatureData, barDataModel => barDataModel.key == value);
            return obj.value;
        }
        public float getVibForValue(string value)
        {
            barDataModel obj = Array.Find(vibData, barDataModel => barDataModel.key == value);
            return obj.value;
        }
        public float getMaxHumidity()
        {
            return this.humidityData.OfType<barDataModel>().Max(barDataModel => barDataModel.value);
        }
        public float getMaxspl()
        {
            return this.splData.OfType<barDataModel>().Max(barDataModel => barDataModel.value);
        }
        public float getMaxTemprature()
        {
            return this.temperatureData.OfType<barDataModel>().Max(barDataModel => barDataModel.value);
        }
        public float getMaxVib()
        {
            return this.vibData.OfType<barDataModel>().Max(barDataModel => barDataModel.value);
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
        public void LoadDetailView()
        {
       
            navigationService.Navigate(PageNames.DetailGraphView,null);

        }

        public async void Initialize(object parameter)
        {
            IDeviceInfo deviceObj=parameter as IDeviceInfo;

            RootObject barGraphdata = (RootObject)await graphService.GetBarGraph2(deviceObj.DeviceId.ToString(), deviceObj.DeviceMacId);
            System.Diagnostics.Debug.WriteLine("GraphData => ", barGraphdata);
          //  RootObject obj2 = (RootObject)obj;


        }
    }
}
