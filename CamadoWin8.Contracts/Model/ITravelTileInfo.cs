using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Contracts.Model
{
    public interface ITravelTileInfo
    {
        int TravelId { get; set; }
        string TravelName { get; set; }
        int ContinentId { get; set; }
        string ImageUrl { get; set; }
    }
}
