using CamadoWin8.Contracts.Model;
using CamadoWin8.Contracts.Services;
using CamadoWin8.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadoWin8.Shared;

namespace CamadoWin8.Services.Data
{
    public class TravelDataService : ITravelDataService
    {
        public async Task<ObservableCollection<IContinentTileInfo>> GetPopularTravels()
        {
            ContinentRepository continentRpository = new ContinentRepository();

            var continents = await continentRpository.GetContinentAndTravelTileInfos();

            //We want to randomize and only show max 4 per continent
            //repo contains cached version of all info instances, we're selecting from that list
            var randomContinents = continents.Shuffle().Take(3);

            return randomContinents.ToObservableCollection();
        }

        public async Task<IContinentDetail> GetContinentDetailAndTravels(string continentId)
        {
            ContinentRepository continentRepository = new ContinentRepository();
            var continent = await continentRepository.GetContinentDetailAndTravels(continentId);

            return continent;

        }

        public async Task<ITravelDetail> GetTravelDetails(string travelId)
        {
            ContinentRepository continentRepository = new ContinentRepository();
            var travel = await continentRepository.GetTravelDetails(travelId);

            return travel;
        }

        public async Task<List<ITravelTileInfo>> GetInfiniteTravelTileInfos()
        {
            ContinentRepository continentRepository = new ContinentRepository();
            var travels = await continentRepository.GetInfiniteTravelData();
            return travels;
        }
    }
}
