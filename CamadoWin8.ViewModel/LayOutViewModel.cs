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
using CamadoWin8.Contracts.View;

namespace CamadoWin8.ViewModel
{
    public class LayOutViewModel : ViewModelBase, ILayOutViewModel
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
        private IDeviceService deviceService;
       

        private ObservableCollection<Menu> menus;

       

        private Menu selectedMenu;
        public Menu SelectedMenu
        {
            get { return selectedMenu; }

            set
            {
                selectedMenu = value;
                RaisePropertyChanged("SelectedMenu");            
                navigationService.Navigate(SelectedMenu.PageName, null);
            }
        }

    

        public ObservableCollection<Menu> Menus
        {
            get { return menus; }

            set
            {
                menus = value;
                RaisePropertyChanged("Menus");
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

      
          public RelayCommand<IDeviceInfo> SelectedCommand { get; set; }
       // public RelayCommand SelectedCommand { get; set; }
        public LayOutViewModel( INavigationService navigationService, IDialogService dialogService, IShareContractService shareContractService,
            ITileService tileService, IToastService toastService, IStateService stateService,IDeviceService deviceService)
        {
            
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
              
                 navigationService.Navigate(PageNames.GraphView,
                     deviceObj.DeviceId);
             });

       
        }

        public  void Initialize(object parameter)
        {
           
            List<Menu> menus = new List<Menu>();
            menus.Add(new Menu { Id = 1, Name = "Devices",Type= typeof(IHomeView),PageName=PageNames.HomeView,ImagePath=@"/Assets/ic_home.png" });
            menus.Add(new Menu { Id = 2, Name = "Locations", Type = typeof(ILocationView),PageName=PageNames.LocationView,ImagePath = @"/Assets/ic_location.png" });
            menus.Add(new Menu { Id = 3, Name = "User", Type = typeof(ILocationView), PageName = PageNames.LocationView, ImagePath = @"/Assets/ic_profile.png" });
            Menus = menus.ToObservableCollection();
            SelectedMenu = menus[0];
        }
    }
}
