using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Contracts.Model
{
    public class LocationInfo : ILocationInfo
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string BasePath = @"http://iot.cabotprojects.com:3001/public/assets/images/";
        private string fileName;
        public string FileName {
            get
            {
                if(!(string.IsNullOrEmpty(fileName)))                   
                    return BasePath + fileName;
                return "/Assests/noimage.png";
                
            }
            set { fileName = value; } }
    }
}
