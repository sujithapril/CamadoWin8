using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Contracts.Model
{
    public interface IDeviceInfo
    {
        int DeviceId { get; set; }
        string DeviceMacId { get; set; }
        string NickName { get; set; }
        string Description { get; set; }
        string FileName { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }

    }
}
