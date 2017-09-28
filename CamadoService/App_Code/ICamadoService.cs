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
    public interface ICamadoService
    {
        

        [OperationContract]
        // [WebGet(UriTemplate = "/Devices", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        [WebGet(UriTemplate = "/Devices", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml)]
        string GetDevices();

        [OperationContract]
        // [WebGet(UriTemplate = "/Devices", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        [WebGet(UriTemplate = "/Locations", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml)]
        string GetLocations();

        [OperationContract]
        // [WebGet(UriTemplate = "/Devices", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        [WebGet(UriTemplate = "/BarGraph/{deviceId}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml)]
        string GetBarGraph(string deviceId);

        [OperationContract]
        // [WebGet(UriTemplate = "/Devices", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        [WebGet(UriTemplate = "/LineGraph/{deviceId}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml)]
        string GetLineGraph(string deviceId);

        [OperationContract]      
        [WebGet(UriTemplate = "/Authenticate/{userName}/{password}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Xml)]
        string Authenticate(string userName,string password);
    }
}
