using CamadoWin8.Contracts.Services;
using CamadoWin8.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Services.Data
{
    public class CacheDataService: ICacheDataService
    {
        public void ClearCache()
        {
            new CacheRepository().ClearCache();
        }
    }
}
