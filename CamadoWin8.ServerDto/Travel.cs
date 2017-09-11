using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OnTheRoad.ServerDto
{
    [DataContract(Namespace = "")]
    public class Travel
    {
        [DataMember]
        public int TravelId { get; set; }
        [DataMember]
        public string TravelName { get; set; }
        [DataMember]
        public string ShortTitle { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public string Outline { get; set; }
        [DataMember]
        public int ContinentId { get; set; }
        [DataMember]
        public string ImageUrl { get; set; }
        [DataMember]
        public int Duration { get; set; }
    }
}
