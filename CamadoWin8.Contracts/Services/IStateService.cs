using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CamadoWin8.Contracts.Services
{
    public interface IStateService
    {
        //ApplicationDataContainer LocalSettings { get; set; }
        void SetItem(string name, object value);


        object GetItem(string name)  ;
        string Parameter { get; set; }
        string ViewName { get; set; }
        void SaveState();
        void LoadState();
        void AddState(string viewName, string parameter);
    }
}
