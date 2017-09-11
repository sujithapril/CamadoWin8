using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;

namespace OnTheRoad.Server
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class InfiniteOnTheRoadService
    {
        [OperationContract]
        public List<ServerDto.Travel> GetTravels()
        {
            List<ServerDto.Travel> travels = new List<ServerDto.Travel>();
            for (int i = 0; i < 25; i++)
            {
                ServerDto.Travel r1 = new ServerDto.Travel() { TravelId = 1, ContinentId = 1, Description = "Lorem Ipsum", Duration = 3, Outline = "More lorem ipsum", ShortTitle = "Citytrip London", TravelName = "Citytrip London", ImageUrl = "http://localhost:35756/images/london.jpg" };
                travels.Add(r1);

                ServerDto.Travel r2 = new ServerDto.Travel() { TravelId = 2, ContinentId = 1, Description = "Lorem Ipsum", Duration = 3, Outline = "More lorem ipsum", ShortTitle = "Citytrip Paris", TravelName = "Citytrip Paris", ImageUrl = "http://localhost:35756/images/paris.jpg" };
                travels.Add(r2);

                ServerDto.Travel r3 = new ServerDto.Travel() { TravelId = 3, ContinentId = 1, Description = "Lorem Ipsum", Duration = 3, Outline = "More lorem ipsum", ShortTitle = "Citytrip Barcelona", TravelName = "Citytrip Barcelona", ImageUrl = "http://localhost:35756/images/barcelona.jpg" };
                travels.Add(r3);

                ServerDto.Travel r4 = new ServerDto.Travel() { TravelId = 4, ContinentId = 1, Description = "Lorem Ipsum", Duration = 3, Outline = "More lorem ipsum", ShortTitle = "Citytrip New York", TravelName = "Citytrip New York", ImageUrl = "http://localhost:35756/images/newyork.jpg" };
                travels.Add(r4);

                ServerDto.Travel r5 = new ServerDto.Travel() { TravelId = 5, ContinentId = 1, Description = "Lorem Ipsum", Duration = 3, Outline = "More lorem ipsum", ShortTitle = "Citytrip Tokyo", TravelName = "Citytrip Tokyo", ImageUrl = "http://localhost:35756/images/tokyo.jpg" };
                travels.Add(r5);

            }
            return travels;
        }

        // Add more operations here and mark them with [OperationContract]
    }
}
