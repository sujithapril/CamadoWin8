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
using CamadoWin8.Model;

namespace CamadoWin8.ViewModel
{
    public class LogInViewModel : ViewModelBase, ILogInViewModel
    {
        public RelayCommand GoBack { get; set; }
        public RelayCommand GoHome { get; set; }
        public RelayCommand AddToFavorites { get; set; }


       // private ITravelDataService travelDataService;
        private INavigationService navigationService;
        private IAuthenticateService authenticateService;
        private IDialogService dialogService;
        private IShareContractService shareContractService;
        private ITileService tileService;
        private IToastService toastService;
        private IStateService stateService;

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
        public RelayCommand SignInCommand { get; set; }
        public LogInViewModel( INavigationService navigationService, IDialogService dialogService, IShareContractService shareContractService,
            ITileService tileService, IToastService toastService, IStateService stateService, IAuthenticateService authenticateService)
        {
            
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.shareContractService = shareContractService;
            this.tileService = tileService;
            this.toastService = toastService;
            this.stateService = stateService;
            this.authenticateService = authenticateService;
            InitializeCommands();

        }

        private void InitializeCommands()
        {
            SignInCommand= new RelayCommand(async() =>
            {
                if (UserName != null && Password != null && UserName.Length > 0 && Password.Length > 0) {
                    //navigationService.Navigate(PageNames.HomeView, UserName);
                    LogInResponse logInResponse = null;
                    if (!await ApplicationVariables.IOnLine())
                    {
                        logInResponse = (LogInResponse)await authenticateService.Authenticate2(UserName, Password);
                    }
                    else
                    {
                        logInResponse = (LogInResponse)await authenticateService.Authenticate(UserName, Password);

                    }
                 
                if (logInResponse.status == "1")
                {
                    stateService.SetItem("currentUserToken", logInResponse.authToken);
                    stateService.SetItem("currentUserId", logInResponse.userId);
                    stateService.SetItem("currentUserOrgId", logInResponse.orgId);
                    navigationService.Navigate(PageNames.LayOutView, UserName);
                }
                else
                {
                    toastService.SendSimpleTextToast("Error while logging in");
                }

            }
                else
                {
                    toastService.SendSimpleTextToast("Please enter Username and Password");
                }
            });
          
        }

        public async void Initialize(object parameter)
        {
          
        }
    }
}
