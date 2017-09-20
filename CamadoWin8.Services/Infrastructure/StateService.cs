using CamadoWin8.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CamadoWin8.Services.Infrastructure
{
    public class StateService : IStateService
    {
         ApplicationDataContainer localSettings = null;
        public string Parameter { get; set; }
        public string ViewName { get; set; }

        public StateService()
        {
            localSettings = ApplicationData.Current.LocalSettings;

        }
        //public ApplicationDataContainer LocalSettings {

        //    get { return localSettings; }
        //    set { localSettings = value; }
        //}

        public void AddState(string viewName, string parameter)
        {
            this.ViewName = viewName;
            this.Parameter = parameter;
        }

        public void SaveState()
        {
            if (ViewName != null && Parameter != null)
            {
                localSettings.Values["viewName"] = ViewName;
                localSettings.Values["parameter"] = Parameter;
            }
        }

        public void LoadState()
        {
            try
            {
                ViewName = localSettings.Values["viewName"].ToString();
                Parameter = localSettings.Values["parameter"].ToString();
            }
            catch { }
        }


        public void SetItem(string name,string value)
        {
            localSettings.Values[name] = value;
          
        }

        public object GetItem(string name)
        {
            try
            {
              return localSettings.Values[name];
              
            }
            catch { return string.Empty; }
        }
    }
}
