using CamadoWin8.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Model
{
    public class ContinentTileInfo: IContinentTileInfo
    {
        public int ContinentId
        {
            get;
            set;
        }

        public string ContinentName
        {
            get;
            set;
        }

        public List<ITravelTileInfo> Travels
        {
            get;
            set;
        }


        public string ImageUrl
        {
            get;
            set;
        }
    }
}
