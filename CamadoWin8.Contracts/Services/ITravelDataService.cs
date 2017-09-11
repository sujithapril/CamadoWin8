using CamadoWin8.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Contracts.Services
{
    public interface ITravelDataService
    {
        Task<ObservableCollection<IContinentTileInfo>> GetPopularTravels();
        Task<IContinentDetail> GetContinentDetailAndTravels(string continentId);
        Task<ITravelDetail> GetTravelDetails(string travelId);
        Task<List<ITravelTileInfo>> GetInfiniteTravelTileInfos();
    }
}
