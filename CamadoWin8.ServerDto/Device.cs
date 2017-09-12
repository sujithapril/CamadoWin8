using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnTheRoad.ServerDto
{
    [DataContract(Namespace = "")]
    public class Device
    {
        [DataMember]
        public int DeviceId { get; set; }
        [DataMember]
        public string DeviceMacId { get; set; }
        [DataMember]
        public string NickName { get; set; }
        [DataMember]
        public string Description { get; set; }
       
    }
       
    
}
