using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Model
{
    

    public class DeviceResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<ResponseRow> responseRows { get; set; }
    }
    public class ResponseRow
    {
        public int cnt { get; set; }
        public string notificationStatus { get; set; }
        public string alert { get; set; }
        public string warning { get; set; }
        public DateTime lastDataTime { get; set; }
        public int? alertId { get; set; }
        public int deviceId { get; set; }
        public string deviceMacId { get; set; }
        public string nickName { get; set; }
        public int? locationId { get; set; }
        public string locationName { get; set; }
        public string mediaId { get; set; }
        public string imageName { get; set; }
        public int status { get; set; }
        public int color { get; set; }
    }
}
