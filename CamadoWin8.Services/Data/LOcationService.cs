using CamadoWin8.Contracts.Model;
using CamadoWin8.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CamadoWin8.Shared;
using Windows.Web.Http;
using Newtonsoft.Json;
using CamadoWin8.Model;

namespace CamadoWin8.Services.Data
{
    public class LocationService : ILocationService
    {
        private IStateService stateService;
        public LocationService(IStateService stateService)
        {
            this.stateService = stateService;
        }
        //public async Task<IEnumerable<IDeviceInfo>> GetDeviceList()
        //{

        //    var c = new HttpClient();
        //    var resp = await c.GetAsync(new Uri("http://localhost/CamadoService/CamadoService.svc/Devices"));
        //    var prod = await resp.Content.ReadAsStringAsync();
        //    // dynamic cc= JsonConvert.DeserializeObject<def>(prod);
        //    //Console.WriteLine(cc[0].DeviceId);
        //    List<DeviceInfo> deviceinfoList = JsonConvert.DeserializeObject<List<DeviceInfo>>(prod);


        //    return deviceinfoList.AsEnumerable();
        //}
        public async Task<IEnumerable<ILocationInfo>> GetLocationList(string a,string b,string c)
        {
            return null;
        }
        public async Task<IEnumerable<ILocationInfo>> GetLocationList()
        {

            string requestBodyField = string.Empty; ;
            //RequestBodyField=
            string resourceAddress = "http://iot.cabotprojects.com:3001/tokenValidate";
            var httpClient = new HttpClient();           
            httpClient.DefaultRequestHeaders.Add("authtoken",stateService.GetItem("currentUserToken").ToString());
            httpClient.DefaultRequestHeaders.Add("orgId", stateService.GetItem("currentUserOrgId").ToString());
            httpClient.DefaultRequestHeaders.Add("userId", stateService.GetItem("currentUserId").ToString());
            httpClient.DefaultRequestHeaders.Add("deviceToken", "123");
            httpClient.DefaultRequestHeaders.Add("clientDeviceId", "12");
            CommonRequest r = new CommonRequest();
            r.data = "{\"limit\":" + 1000 + ",\"offset\": " + 0 + ",\"searchKey\": \"\",\"sort\": \"asc\"} ";
            r.method = "get";
            r.endpoint = "location/list";
            requestBodyField = JsonConvert.SerializeObject(r);

            //string a = "{\"data\"" + ":" + "{\"userName\":\"kiran\",\"password\":\"kiran\",\"organisationName\":\"cabot\",\"deviceToken\":\"123\",\"deviceType\":\"web\",\"clientDeviceId\":\"12\"}" + "," + "\"endpoint\"" + ":" + "\"user/login\"" + "," + "\"method\"" + ":" + "\"post\"}";

            HttpResponseMessage response = await httpClient.PostAsync(new Uri(resourceAddress),
                     new HttpStringContent(requestBodyField, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
            var deviceliststring = await response.Content.ReadAsStringAsync();
            // var deviceResponse = JsonConvert.DeserializeObject<LogInResponse>(deviceliststring);
           LocationResponse locationResponse = JsonConvert.DeserializeObject<LocationResponse>(deviceliststring);
            List<LocationInfo> locationinfoList = new List<LocationInfo>();

          foreach (ResponseRowsLocation row in locationResponse.responseRowsLocations)
            {
                locationinfoList.Add(new LocationInfo { LocationId = row.locationId, LocationName = row.locationName, FileName = row.fileName });
            }
            //  List<DeviceInfo> deviceinfoList = JsonConvert.DeserializeObject<List<DeviceInfo>>(deviceliststring);


            return locationinfoList.AsEnumerable();
        }
    }
}
