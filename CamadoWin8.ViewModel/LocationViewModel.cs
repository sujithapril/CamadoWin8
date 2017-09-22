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
    public class LocationViewModel : ViewModelBase, ILocationViewModel
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
        private ILocationService locationService;
 


        private ObservableCollection<ILocationInfo> locationTileInfos;

        public ObservableCollection<ILocationInfo>LocationTileInfos
        {
            get
            {
                return locationTileInfos;
            }
            set
            {
                locationTileInfos = value;
                RaisePropertyChanged("LocationTileInfos");
            }
        }

   
          public RelayCommand<IDeviceInfo> SelectedCommand { get; set; }
       // public RelayCommand SelectedCommand { get; set; }
        public LocationViewModel( INavigationService navigationService, IDialogService dialogService, IShareContractService shareContractService,
            ITileService tileService, IToastService toastService, IStateService stateService,ILocationService locationService)
        {
            
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.shareContractService = shareContractService;
            this.tileService = tileService;
            this.toastService = toastService;
            this.stateService = stateService;
            this.locationService = locationService;
            InitializeCommands();

        }

        private void InitializeCommands()
        {
            SelectedCommand = new RelayCommand<IDeviceInfo>((deviceObj) =>
             {
                 toastService.SendSimpleTextToast("Hello YOU  clicked me!");
                 //navigationService.Navigate(PageNames.GraphView,
                 //    deviceObj.DeviceId);
             });

          
        }

        public async void Initialize(object parameter)
        {
           
            IEnumerable<ILocationInfo> ilocationenumerableList =  await locationService.GetLocationList();

            LocationTileInfos = ilocationenumerableList.ToObservableCollection();
        }
    }
}
