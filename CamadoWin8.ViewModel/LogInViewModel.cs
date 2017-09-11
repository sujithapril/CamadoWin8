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

namespace CamadoWin8.ViewModel
{
    public class LogInViewModel : ViewModelBase, ILogInViewModel
    {
        public RelayCommand GoBack { get; set; }
        public RelayCommand GoHome { get; set; }
        public RelayCommand AddToFavorites { get; set; }


        private ITravelDataService travelDataService;
        private INavigationService navigationService;
        private IDialogService dialogService;
        private IShareContractService shareContractService;
        private ITileService tileService;
        private IToastService toastService;
        private IStateService stateService;

        private ITravelDetail selectedTravelDetail;
        public ITravelDetail SelectedTravelDetail
        {
            get
            {
                return selectedTravelDetail;
            }
            set
            {
                selectedTravelDetail = value;
                shareContractService.SharedTravelDetail = SelectedTravelDetail;
                tileService.SendSimpleTextUpdate
                    (SelectedTravelDetail.TravelName);
                //tileService.SendImageAndTextUpdate(SelectedTravelDetail.TravelName, SelectedTravelDetail.ImageUrl);
                //toastService.SendImageAndTextToast(SelectedTravelDetail.TravelName, SelectedTravelDetail.ImageUrl);

                stateService.AddState(PageNames.TravelDetailView, 
                    selectedTravelDetail.TravelId.ToString());
                RaisePropertyChanged("SelectedTravelDetail");
            }
        }

        public LogInViewModel(ITravelDataService travelDataService, INavigationService navigationService, IDialogService dialogService, IShareContractService shareContractService,
            ITileService tileService, IToastService toastService, IStateService stateService)
        {
            this.travelDataService = travelDataService;
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.shareContractService = shareContractService;
            this.tileService = tileService;
            this.toastService = toastService;
            this.stateService = stateService;

            InitializeCommands();

        }

        private void InitializeCommands()
        {
            GoBack = new RelayCommand(() =>
            {
                navigationService.GoBack();
            });
            GoHome = new RelayCommand(() =>
            {
                navigationService.Navigate(PageNames.PopularTravelView);
            });
            AddToFavorites = new RelayCommand(() => 
            {
                dialogService.ShowAddToFavoriteConfirmation();
            });
        }

        public async void Initialize(object parameter)
        {
           // SelectedTravelDetail = await travelDataService.GetTravelDetails(parameter.ToString());

           // shareContractService.Initialize();
        }
    }
}
