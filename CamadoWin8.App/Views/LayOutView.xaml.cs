using CamadoWin8.App.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using CamadoWin8.Contracts.View;
using CamadoWin8.Contracts.ViewModels;
using CamadoWin8.Contracts.Services;
// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace CamadoWin8.App.Views
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class LayOutView : Page,ILayOutView
    {
        

        public LayOutView()
        {
           
            this.InitializeComponent();

            ((CamadoWin8.ViewModel.LayOutViewModel)ViewModel).navigationService.Frame = this.ContentFrame;
        }
      

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // this.navigationService.Frame = ContentFrame;
            ((CamadoWin8.ViewModel.LayOutViewModel)ViewModel).navigationService.Frame = this.ContentFrame;


        }

        public IViewModel ViewModel
        {
            get { return this.DataContext as IViewModel; }
        }

     
    }
}
