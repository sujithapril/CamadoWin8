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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string BasePath = @"http://iot.cabotprojects.com:3001/public/assets/images/";
        private string fileName;
        public string FileName
        {
            get
            {
                if (!(string.IsNullOrEmpty(fileName)))
                    return BasePath + fileName;
                return "/Assets/noimage.png";

            }
            set { fileName = value; }
        }
    }
}

