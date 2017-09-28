using CamadoWin8.Contracts.Services;
using CamadoWin8.Contracts.View;
using CamadoWin8.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace CamadoWin8.Services.Infrastructure
{
    public class NavigationService : INavigationService
    {
        private Frame frame;
        public Frame Frame
        {
            get
            {
                return frame;
            }
            set
            {
                frame = value;
                frame.Navigated += OnFrameNavigated;
            }
        }
        private IStateService stateService;
        public NavigationService(IStateService stateService)
        {
            this.stateService = stateService;

        }

        public void Navigate(Type type)
        {
            Frame.Navigate(type);
        }

        public void Navigate(Type type, object parameter)
        {
            Frame.Navigate(type, parameter);
        }

        public void Navigate(string type, object parameter)
        {
            switch (type)
            {
                
                case PageNames.LogInView:
                    {
                        Frame rootFrame=ApplicationVariables.RootFrame as Frame;
                        if (rootFrame != null)
                            Frame = rootFrame;
                        Navigate<ILogInView>(parameter); break;
                    }
                case PageNames.HomeView:
                    Navigate<IHomeView>(parameter); break;
                case PageNames.GraphView:
                    Navigate<IGraphView>(parameter); break;
                case PageNames.LayOutView:
                    Navigate<ILayOutView>(parameter); break;
                case PageNames.LocationView:
                   Navigate<ILocationView>(parameter); break;
                case PageNames.DetailGraphView:
                    Navigate<IDetailGraphView>(parameter);break;
            }
        }

        private void Navigate<T>(object parameter) where T : IView
        {
            DisposePreviousView();
            var viewType = InstanceFactory.Registrations.ContainsKey(typeof(T)) ? InstanceFactory.Registrations[typeof(T)] : typeof(T);
            Frame.Navigate(viewType, parameter);
        }

        public IView CurrentView
        {
            get { return frame.Content as IView; }
        }

        private void DisposePreviousView()
        {
            try
            {
                if (this.CurrentView != null && ((Page)this.CurrentView).NavigationCacheMode ==
                    Windows.UI.Xaml.Navigation.NavigationCacheMode.Disabled)
                {
                    var currentView = this.CurrentView;
                    var currentViewDisposable = currentView as IDisposable;

                    // if(currentView is BasePage
                    if (currentViewDisposable != null)
                    {
                        currentViewDisposable.Dispose();
                        currentViewDisposable = null;
                    } //view model is disposed in the view implementation
                    currentView = null;
                    GC.Collect();
                }
            }
            catch { }
        }

        public void Navigate(string type)
        {
            Frame.Navigate(Type.GetType(type));
        }

        public void GoBack()
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
            }
        }

        private void OnFrameNavigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            var view = e.Content as IView;
            if (view == null)
                return;
            Type t = e.SourcePageType;
           
            var viewModel = view.ViewModel;
            if (viewModel != null)
            {
                if (!(e.NavigationMode ==
                    Windows.UI.Xaml.Navigation.NavigationMode.Back
                    &&
                    (((Page)e.Content).NavigationCacheMode ==
                    Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled ||
                    (((Page)e.Content).NavigationCacheMode ==
                    Windows.UI.Xaml.Navigation.NavigationCacheMode.Required))))
                {
                    viewModel.Initialize(e.Parameter);
                }
            }
        }
    }
}
