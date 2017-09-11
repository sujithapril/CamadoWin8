using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;

namespace OnTheRoad.Server
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOnTheRoadTravelService" in both code and config file together.
    [ServiceContract]
    public interface IOnTheRoadTravelService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/PopularTravels", BodyStyle=WebMessageBodyStyle.Bare, ResponseFormat=WebMessageFormat.Xml)]
        List<OnTheRoad.ServerDto.Continent> GetPopularTravels();

        [OperationContract]
        [WebGet(UriTemplate = "/TravelsPerContinent/{continentId}")]
        ServerDto.Continent GetTravelsForContinent(string continentId);

        [OperationContract]
        [WebGet(UriTemplate = "/Travels/{travelId}")]
        ServerDto.Travel GetTravelDetails(string travelId);
    }
}
