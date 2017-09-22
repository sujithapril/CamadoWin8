using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Model
{


    public class ResponseRowsLocation
    {
        public int cnt { get; set; }
        public string locationName { get; set; }
        public int locationId { get; set; }
        public int? mediaId { get; set; }
        public string fileName { get; set; }
        public string type { get; set; }
    }

    public class LocationResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public List<ResponseRowsLocation> responseRowsLocations { get; set; }
    }
}
