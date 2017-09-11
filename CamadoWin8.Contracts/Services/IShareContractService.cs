using CamadoWin8.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Contracts.Services
{
    public interface IShareContractService
    {
        ITravelDetail SharedTravelDetail { get; set; }
        void Initialize();
    }
}
