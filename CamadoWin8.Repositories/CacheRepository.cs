using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace CamadoWin8.Repositories
{
    public class CacheRepository
    {
        public async void ClearCache()
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;
            await StorageHelper.ClearCache(folder);
        }
    }
}
