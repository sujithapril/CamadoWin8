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


            IRootObject obj = await graphService.GetBarGraph2(parameter.ToString());
            RootObject obj2 = (RootObject)obj;


        }
    }
}
