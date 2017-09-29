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
    public class HomeViewModel : ViewModelBase, IHomeViewModel
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
        private IDeviceService deviceService;
        private string username;
        public string UserName
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                RaisePropertyChanged("UserName");
            }
        }
        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
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
       // public RelayCommand SelectedCommand { get; set; }
        public HomeViewModel( INavigationService navigationService, IDialogService dialogService, IShareContractService shareContractService,
            ITileService tileService, IToastService toastService, IStateService stateService,IDeviceService deviceService)
        {
            DeviceTileInfos = new ObservableCollection<IDeviceInfo>();
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.shareContractService = shareContractService;
            this.tileService = tileService;
            this.toastService = toastService;
            this.stateService = stateService;
            this.deviceService = deviceService;
            InitializeCommands();

        }

        private void InitializeCommands()
        {
            SelectedCommand = new RelayCommand<IDeviceInfo>((deviceObj) =>
             {
                // toastService.SendSimpleTextToast("Hello YOU  clicked me!");
                 navigationService.Navigate(PageNames.GraphView,
                     deviceObj);
             });

            //SelectedCommand = new RelayCommand(() =>
            //{
            //    toastService.SendSimpleTextToast("Hello clicked me!");
            //});
            //GoBack = new RelayCommand(() =>
            //{
            //    navigationService.GoBack();
            //});
            //GoHome = new RelayCommand(() =>
            //{
            //    navigationService.Navigate(PageNames.PopularTravelView);
            //});
            //AddToFavorites = new RelayCommand(() => 
            //{
            //    dialogService.ShowAddToFavoriteConfirmation();
            //});
        }

        public async void Initialize(object parameter)
        {
            //if (DeviceTileInfos.Count == 0)
            //{
            // SelectedTravelDetail = await travelDataService.GetTravelDetails(parameter.ToString());

            // shareContractService.Initialize();

            IEnumerable<IDeviceInfo> ideviceenumerableList = null;
            if (!await ApplicationVariables.IOnLine())
            {
                ideviceenumerableList = await deviceService.GetDeviceList2();
            }
            else
            {
                ideviceenumerableList = await deviceService.GetDeviceList();

            }


            //   DeviceTileInfos = ideviceenumerableList.ToList();
            DeviceTileInfos = ideviceenumerableList.ToObservableCollection();
           // }
        }
    }
}
