using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Contracts.Model
{
    public interface IContinentTileInfo
    {
        int ContinentId { get; set; }
        string ContinentName { get; set; }
        string ImageUrl { get; set; }        
        List<ITravelTileInfo> Travels { get; set; }
    }
}
