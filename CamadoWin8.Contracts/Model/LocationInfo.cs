using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Contracts.Model
{
    public interface ILocationInfo
    {
        int LocationId { get; set; }
        string LocationName { get; set; }
        string FileName { get; set; }
        
    }
}
