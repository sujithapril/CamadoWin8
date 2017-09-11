using CamadoWin8.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Model
{
    public class TravelDetail : ITravelDetail
    {
        public int TravelId
        {
            get;
            set;
        }

        public string TravelName
        {
            get;
            set;
        }

        public string ShortTitle
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public string Outline
        {
            get;
            set;
        }

        public int ContinentId
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public int Duration
        {
            get;
            set;
        }
    }
}
