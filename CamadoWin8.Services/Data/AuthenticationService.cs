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
using CamadoWin8.Contracts.Model;
using CamadoWin8.Model;

namespace CamadoWin8.Services.Data
{
    public class AuthenticateService : IAuthenticateService
    {

        public async Task<ILogInResponse> Authenticate(string userName, string password)
        {
            string requestBodyField = string.Empty; ;        
            
            string resourceAddress = "http://iot.cabotprojects.com:3001/tokenValidate";
            var httpClient = new HttpClient();
            //httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36");
            //httpClient.DefaultRequestHeaders.Accept.TryParseAdd("application/json, text/plain, */*");
            //httpClient.DefaultRequestHeaders.AcceptEncoding.TryParseAdd("gzip, deflate");
            //httpClient.DefaultRequestHeaders.AcceptLanguage.TryParseAdd("en-US,en;q=0.8,en-CA;q=0.6");
            //httpClient.DefaultRequestHeaders.Add("Content - Type","application / json");
            // httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");

            CommonRequest r = new CommonRequest();
            r.data = "{\"userName\":\"" + userName + "\",\"password\": \"" + password + "\",\"organisationName\": \"cabot\",\"deviceToken\": \"123\",\"deviceType\": \"web\",\"clientDeviceId\": \"12\"} ";
            r.method = "post";
            r.endpoint = "user/login";
            requestBodyField = JsonConvert.SerializeObject(r);     
            HttpResponseMessage response = await httpClient.PostAsync(new Uri(resourceAddress),
                     new HttpStringContent(requestBodyField, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
            var login = await response.Content.ReadAsStringAsync();
           var loginResponse= JsonConvert.DeserializeObject<LogInResponse>(login);
          
          


            return loginResponse;
        }

        public async Task<ILogInResponse> Authenticate2(string userName, string password)
        {
            string requestBodyField = string.Empty; ;

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(new Uri("http://localhost/CamadoService/CamadoService.svc/Authenticate/"+userName+"/"+password));           
            var login = await response.Content.ReadAsStringAsync();
            System.Xml.XmlReader reader = System.Xml.XmlReader.Create(new System.IO.StringReader(login));
            reader.Read();
            string loginstring= reader.ReadInnerXml();
            var loginResponse = JsonConvert.DeserializeObject<LogInResponse>(loginstring);
            return loginResponse;
        }
    }
}
