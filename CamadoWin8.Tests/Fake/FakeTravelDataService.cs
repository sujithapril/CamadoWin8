using CamadoWin8.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CamadoWin8.Tests.Fake;
using System.Threading.Tasks;

namespace CamadoWin8.Tests
{
    public class FakeTravelDataService: ITravelDataService
    {
        public async Task<System.Collections.ObjectModel.ObservableCollection<Contracts.Model.IContinentTileInfo>> GetPopularTravels()
        {
            throw new NotImplementedException();
        }

        public async Task<Contracts.Model.IContinentDetail> GetContinentDetailAndTravels(string continentId)
        {
            return new FakeContinentRepository().ContinentDetails.Where(c => c.ContinentId == Int32.Parse(continentId)).FirstOrDefault(); 
        }

        public async Task<Contracts.Model.ITravelDetail> GetTravelDetails(string travelId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Contracts.Model.ITravelTileInfo>> GetInfiniteTravelTileInfos()
        {
            throw new NotImplementedException();
        }
    }
}
