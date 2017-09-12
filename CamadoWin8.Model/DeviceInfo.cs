using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Contracts.Model
{
    public class DeviceInfo:IDeviceInfo
    {
        public int DeviceId { get; set; }
        public string DeviceMacId { get; set; }
        public string NickName { get; set; }
        public string Description { get; set; }
    }
}
