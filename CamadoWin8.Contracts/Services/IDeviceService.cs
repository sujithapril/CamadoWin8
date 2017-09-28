using CamadoWin8.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Contracts.Services
{
    public interface IDeviceService
    {
        Task<IEnumerable<IDeviceInfo>> GetDeviceList();
        Task<IEnumerable<IDeviceInfo>> GetDeviceList2();
        Task<IEnumerable<IDeviceInfo>> GetDeviceList(string userId,string orgId,string Token);
    }
}
