using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace OnTheRoad.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "OnTheRoadTravelService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select OnTheRoadTravelService.svc or OnTheRoadTravelService.svc.cs at the Solution Explorer and start debugging.
    public class OnTheRoadTravelService : IOnTheRoadTravelService
    {
        private OnTheRoadEntities context;

        public OnTheRoadTravelService()
        {
            context = new OnTheRoadEntities();
        }

        public List<OnTheRoad.ServerDto.Continent> GetPopularTravels()
        {
            List<OnTheRoad.ServerDto.Continent> continentDtos = new List<OnTheRoad.ServerDto.Continent>();

            var results = from c in context.Continents.Include("Travels")
                          where c.Travels.Any(t => t.IsPopular)
                          select c;

            foreach (var a in results.ToList())
            {
                continentDtos.Add(ConvertIntoContinentDto(a));
            }

            return continentDtos;
        }

        public OnTheRoad.ServerDto.Continent GetTravelsForContinent(string continentId)
        {
             int id;
             if (Int32.TryParse(continentId, out id))
             {
                 List<OnTheRoad.ServerDto.Travel> dtos = new List<OnTheRoad.ServerDto.Travel>();
                 var results = from c in context.Continents.Include("Travels")
                               where c.ContinentId == id
                               select c;

                 var continent = results.FirstOrDefault();

                 return ConvertIntoContinentDto(continent);
             }
             return null;
        }

        public OnTheRoad.ServerDto.Travel GetTravelDetails(string travelId)
        {
            int id;
            if (Int32.TryParse(travelId, out id))
            {

                var results = from t in context.Travels
                              where t.TravelId == id
                              select t;

                return ConvertIntoTravelDto(results.FirstOrDefault());
            }
            else
                return null;
        }

        private OnTheRoad.ServerDto.Continent ConvertIntoContinentDto(Continent continent)
        {
            OnTheRoad.ServerDto.Continent continentDto = new OnTheRoad.ServerDto.Continent()
                        {
                            ContinentName = continent.ContinentName,
                            ContinentId = continent.ContinentId,
                            Description = continent.Description,
                            ImageUrl = continent.ImageUrl,
                            Travels = new List<OnTheRoad.ServerDto.Travel>()
                        };

            foreach (var travel in continent.Travels)
            {
                var travelDto = ConvertIntoTravelDto(travel);
                continentDto.Travels.Add(travelDto);
            }
            return continentDto;
        }

        private ServerDto.Travel ConvertIntoTravelDto(Travel travel)
        {
            OnTheRoad.ServerDto.Travel travelDto = new ServerDto.Travel() 
            {
                ContinentId = travel.ContinentId,
                Description = travel.Description,
                Duration = travel.Duration,
                ImageUrl = travel.ImageUrl,
                Outline = travel.Outline,
                ShortTitle = travel.ShortTitle,
                TravelId = travel.TravelId,
                TravelName = travel.TravelName
            };
            return travelDto;
        }
    }
}
