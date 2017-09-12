using CamadoWin8.App.Views;
using CamadoWin8.Contracts.Model;
using CamadoWin8.Contracts.Services;
using CamadoWin8.Contracts.View;
using CamadoWin8.Contracts.ViewModels;
using CamadoWin8.Services;
using CamadoWin8.Services.Data;
using CamadoWin8.Services.Infrastructure;
using CamadoWin8.Shared;
using CamadoWin8.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.App
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            //ViewModel registration
          
            InstanceFactory.RegisterType<ILogInViewModel, LogInViewModel>();
            InstanceFactory.RegisterType<IHomeViewModel, HomeViewModel>();



            //View registration
            InstanceFactory.RegisterType<ILogInView,
               LogInView>();
            InstanceFactory.RegisterType<IHomeView,
                HomeView>();

            //Services registration

            InstanceFactory.RegisterType<INavigationService, 
                NavigationService>();
            InstanceFactory.RegisterType<IDialogService, DialogService>();
            InstanceFactory.RegisterType<IPushNotificationService, PushNotificationService>();
            InstanceFactory.RegisterType<IShareContractService, ShareContractService>();
            InstanceFactory.RegisterType<ITileService, TileService>();
            InstanceFactory.RegisterType<IToastService, ToastService>();
            InstanceFactory.RegisterType<IStateService, StateService>();
            InstanceFactory.RegisterType<ICacheDataService, CacheDataService>();

            InstanceFactory.RegisterType<IDeviceService, DeviceService>();

            //Model
            InstanceFactory.RegisterType<IDeviceInfo, DeviceInfo>();
        }



        public ILogInViewModel LogInViewModel
        {
            get
            {
                return InstanceFactory.GetInstance<ILogInViewModel>();
            }
        }

        public IHomeViewModel HomeViewModel
        {
            get
            {
                return InstanceFactory.GetInstance<IHomeViewModel>();
            }
        }
    }
}
