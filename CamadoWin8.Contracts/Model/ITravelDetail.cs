using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Contracts.Model
{
    public interface ITravelDetail
    {
       int TravelId { get; set; }
       string TravelName { get; set; }
       string ShortTitle { get; set; }
       string Description { get; set; }
       string Outline { get; set; }
       int ContinentId { get; set; }
       string ImageUrl { get; set; }
       int Duration { get; set; }
    }
}
