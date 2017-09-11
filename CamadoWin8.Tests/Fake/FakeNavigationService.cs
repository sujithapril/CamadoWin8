using CamadoWin8.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CamadoWin8.Tests
{
    public class FakeNavigationService: INavigationService
    {
        public Windows.UI.Xaml.Controls.Frame Frame
        {
            get;
            set;
        }

        public void Navigate(Type type)
        {
        }

        public void Navigate(Type type, object parameter)
        {
           
        }

        public void Navigate(string type)
        {
           
        }

        public void Navigate(string type, object parameter)
        {
        }

        public void GoBack()
        {
        }
    }
}
