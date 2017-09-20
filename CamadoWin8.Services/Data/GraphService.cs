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
using CamadoWin8.Services.Infrastructure;
using CamadoWin8.Model;

namespace CamadoWin8.Services.Data
{
    public class GraphService : IGraphService
    {
        private IStateService stateService;
        public GraphService(IStateService stateService)
        {
            this.stateService = stateService;
        }

        public async Task<string> GetBarGraph(string deviceId)
        {

            var c = new HttpClient();
            var resp = await c.GetAsync(new Uri("http://localhost/CamadoService/CamadoService.svc/BarGraph/"+ deviceId));
            var prod = await resp.Content.ReadAsStringAsync();
            // dynamic cc= JsonConvert.DeserializeObject<def>(prod);
            //Console.WriteLine(cc[0].DeviceId);
            return prod;
        }
        public async Task<IRootObject> GetBarGraph2(string deviceId,string devicemacId)
        {

            //  var c = new HttpClient();
            //  var resp = await c.GetAsync(new Uri("http://localhost/CamadoService/CamadoService.svc/BarGraph/" + deviceId));
            //  var prod = await resp.Content.ReadAsStringAsync();
            //  // dynamic cc= JsonConvert.DeserializeObject<def>(prod);
            //  //Console.WriteLine(cc[0].DeviceId);
            //System.Xml. XmlReader xmlReader = System.Xml.XmlReader.Create(new System.IO.StringReader(prod));
            //  xmlReader.Read();
            //  string inner = xmlReader.ReadInnerXml();
            //  // xmlReader.Value
            //  //string a = xmlDoc.InnerText;
            //  var rootObj = JsonConvert.DeserializeObject<RootObject>(inner);
            //  //var rootObj= JsonConvert.DeserializeObject<RootObject>(prod);
            //  return rootObj;

            string requestBodyField = string.Empty; ;
            string startDate = string.Empty; ;
            string timeZone = string.Empty; ;
            TimeSpan t = (new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,0,0,0)).ToUniversalTime() - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            startDate = secondsSinceEpoch.ToString();
            timeZone = "19800";
            //RequestBodyField=
            string resourceAddress = "http://iot.cabotprojects.com:3001/tokenValidate";
            var httpClient = new HttpClient();        
            httpClient.DefaultRequestHeaders.Add("authtoken", stateService.GetItem("currentUserToken").ToString());
            httpClient.DefaultRequestHeaders.Add("orgId", stateService.GetItem("currentUserOrgId").ToString());
            httpClient.DefaultRequestHeaders.Add("userId", stateService.GetItem("currentUserId").ToString());
            httpClient.DefaultRequestHeaders.Add("deviceToken", "123");
            httpClient.DefaultRequestHeaders.Add("clientDeviceId", "12");
            CommonRequest r = new CommonRequest();
            r.data = "{\"deviceId\":" + deviceId + ",\"deviceMacId\": " + devicemacId + ",\"startDate\":"+ startDate + ",\"timeZone\":"+timeZone+" } ";
            //"{"deviceId":"118","deviceMacId":"101","startDate":"1505889000","timeZone":19800}"
            r.method = "post";
            r.endpoint = "compare";
            requestBodyField = JsonConvert.SerializeObject(r);

            HttpResponseMessage response = await httpClient.PostAsync(new Uri(resourceAddress),
                     new HttpStringContent(requestBodyField, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
            var bargraphstring = await response.Content.ReadAsStringAsync();
            RootObject rootObj=new RootObject();
            try
            {
                rootObj = JsonConvert.DeserializeObject<RootObject>(bargraphstring);
            }
            catch { }

            return rootObj;
        }
    }
}
