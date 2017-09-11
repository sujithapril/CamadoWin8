using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnTheRoad.ServerDto
{
    [DataContract(Namespace="")]
    public class Continent
    {
        [DataMember]
        public int ContinentId { get; set; }
        [DataMember]
        public string ContinentName { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public List<OnTheRoad.ServerDto.Travel> Travels { get; set; }
    }
}
