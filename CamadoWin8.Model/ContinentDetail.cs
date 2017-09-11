using CamadoWin8.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Model
{
    public class ContinentDetail : IContinentDetail
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

        public string ImageUrl
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public List<ITravelTileInfo> Travels
        {
            get;
            set;
        }
    }
}
