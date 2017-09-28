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
    public class DeviceService : IDeviceService
    {
        private IStateService stateService;
        public DeviceService(IStateService stateService)
        {
            this.stateService = stateService;
        }
        public async Task<IEnumerable<IDeviceInfo>> GetDeviceList2()
        {

            var c = new HttpClient();
            var resp = await c.GetAsync(new Uri("http://localhost/CamadoService/CamadoService.svc/Devices"));
            var prod = await resp.Content.ReadAsStringAsync();
            System.Xml.XmlReader reader = System.Xml.XmlReader.Create(new System.IO.StringReader(prod));
            reader.Read();
            string devicestring = reader.ReadInnerXml();
            DeviceResponse deviceResponse = JsonConvert.DeserializeObject<DeviceResponse>(devicestring);
            List<DeviceInfo> deviceinfoList = new List<DeviceInfo>();

            foreach (ResponseRow row in deviceResponse.responseRows)
            {
                if (!string.IsNullOrEmpty(row.imageName))
                    deviceinfoList.Add(new DeviceInfo { DeviceId = row.deviceId, DeviceMacId = row.deviceMacId, NickName = row.nickName, Description = "", FileName = row.imageName });
            }
           

            return deviceinfoList.AsEnumerable();

          
        }
        public async Task<IEnumerable<IDeviceInfo>> GetDeviceList(string a,string b,string c)
        {
            return null;
        }
        public async Task<IEnumerable<IDeviceInfo>> GetDeviceList()
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
            r.endpoint = "device/list";
            requestBodyField = JsonConvert.SerializeObject(r);

    
            HttpResponseMessage response = await httpClient.PostAsync(new Uri(resourceAddress),
                     new HttpStringContent(requestBodyField, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
            var deviceliststring = await response.Content.ReadAsStringAsync();
            // var deviceResponse = JsonConvert.DeserializeObject<LogInResponse>(deviceliststring);
           DeviceResponse deviceResponse = JsonConvert.DeserializeObject<DeviceResponse>(deviceliststring);
            List<DeviceInfo> deviceinfoList = new List<DeviceInfo>();

          foreach (ResponseRow row in deviceResponse.responseRows)
            {
                if(!string.IsNullOrEmpty(row.imageName))
                deviceinfoList.Add(new DeviceInfo { DeviceId = row.deviceId, DeviceMacId = row.deviceMacId, NickName = row.nickName, Description = "",FileName=row.imageName });
            }
            //  List<DeviceInfo> deviceinfoList = JsonConvert.DeserializeObject<List<DeviceInfo>>(deviceliststring);


            return deviceinfoList.AsEnumerable();
        }
    }
}
