﻿using CamadoWin8.Contracts.Model;
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

        public async Task<IRootObject> GetBarGraph(string deviceId, string devicemacId)
        {

            var c = new HttpClient();
            var resp = await c.GetAsync(new Uri("http://localhost/CamadoService/CamadoService.svc/BarGraph/"+ deviceId));
            var bargraphstring = await resp.Content.ReadAsStringAsync();
            System.Xml.XmlReader reader = System.Xml.XmlReader.Create(new System.IO.StringReader(bargraphstring));
            reader.Read();
            string bargraph = reader.ReadInnerXml();
            RootObject rootObj = new RootObject();
            try
            {
                rootObj = JsonConvert.DeserializeObject<RootObject>(bargraph);
            }
            catch { }

            return rootObj;
        }
        public async Task<IRootObject> GetBarGraph2(string deviceId,string devicemacId)
        {

          

            string requestBodyField = string.Empty; ;
            string startDate = string.Empty; ;
            string timeZone = string.Empty; ;
            TimeSpan t = (new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,0,0,0)).ToUniversalTime() - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
             startDate = secondsSinceEpoch.ToString();
            //startDate = "1506038400";
            timeZone = "19800";
            //RequestBodyField=
            string resourceAddress = "http://iot.cabotprojects.com:3001/tokenValidate";
            var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd("Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36");
            httpClient.DefaultRequestHeaders.Accept.TryParseAdd("application/json, text/plain, */*");
            httpClient.DefaultRequestHeaders.AcceptEncoding.TryParseAdd("gzip, deflate");
            httpClient.DefaultRequestHeaders.AcceptLanguage.TryParseAdd("en-US,en;q=0.8,en-CA;q=0.6");

            httpClient.DefaultRequestHeaders.Add("authtoken", stateService.GetItem("currentUserToken").ToString());
            httpClient.DefaultRequestHeaders.Add("orgId", stateService.GetItem("currentUserOrgId").ToString());
            httpClient.DefaultRequestHeaders.Add("userId", stateService.GetItem("currentUserId").ToString());
            httpClient.DefaultRequestHeaders.Add("deviceToken", "123");
            httpClient.DefaultRequestHeaders.Add("clientDeviceId", "12");
            CommonRequest r = new CommonRequest();
            // r.data = "{\"deviceId\":" + deviceId + ",\"deviceMacId\": " + devicemacId + ",\"startDate\":"+ startDate + ",\"timeZone\":"+timeZone+" } ";
            r.data = "{\"deviceId\":" + deviceId + ",\"deviceMacId\": \"" + devicemacId + "\",\"startDate\":\"" + startDate + "\",\"timeZone\":" + timeZone + " } ";
            //"{"deviceId":"118","deviceMacId":"101","startDate":"1505889000","timeZone":19800}"
            r.method = "post";
            r.endpoint = "compare";
            requestBodyField = JsonConvert.SerializeObject(r);

            HttpResponseMessage response = await httpClient.PostAsync(new Uri(resourceAddress),
                     new HttpStringContent(requestBodyField, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
            //HttpResponseMessage response = await httpClient.PostAsync(new Uri(resourceAddress),
            //    new HttpStringContent(requestBodyField));
            var bargraphstring = await response.Content.ReadAsStringAsync();
            RootObject rootObj=new RootObject();
            try
            {
                rootObj = JsonConvert.DeserializeObject<RootObject>(bargraphstring);
            }
            catch { }

            return rootObj;
        }

        public async Task<IRootObjectLIne> GetLineGraph(string startDate, string endDate,string devicemacId,string aggregateFunction)
        {



            string requestBodyField = string.Empty; ;
            
            string timeZone = string.Empty; ;
            TimeSpan t = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)).ToUniversalTime() - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            //startDate = secondsSinceEpoch.ToString();
            //    startDate = "2017-09-26T03:04:00Z";
            //  endDate   = "2017-09-26T05:07:00Z";
            // devicemacId = "5CCF7FA391AB";
         //   startDate = "2017-09-28T03:04:00Z";
         //   endDate = "2017-09-28T04:07:00Z";
         //   devicemacId = "5CCF7FA391AB";
	        //aggregateFunction = "MAX";
            aggregateFunction = "MAX";
            //RequestBodyField=
            string resourceAddress = "http://iot.cabotprojects.com:3000/history ";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("authtoken", stateService.GetItem("currentUserToken").ToString());
            httpClient.DefaultRequestHeaders.Add("orgId", stateService.GetItem("currentUserOrgId").ToString());
            httpClient.DefaultRequestHeaders.Add("userId", stateService.GetItem("currentUserId").ToString());
            httpClient.DefaultRequestHeaders.Add("deviceToken", "123");
            httpClient.DefaultRequestHeaders.Add("clientDeviceId", "12");
            CommonRequest r = new CommonRequest();
            //    r.data = "{\"startDate\":\"" + startDate + "\",\"endDate\": \"" + endDate + "\",\"deviceMacId\":\"" + devicemacId + "\",\"aggregateFunction\":\"" + aggregateFunction + "\" } ";
            r.data = "{\"startDate\":\"" + startDate + "\",\"endDate\": \"" + endDate + "\",\"deviceMacId\":\"" + devicemacId + "\",\"aggregateFunction\":\"" + aggregateFunction + "\" } ";
            LineRequest l = new LineRequest();
            l.aggregateFunction = "MAX";
            l.deviceMacId = devicemacId;
            l.startDate =( startDate);
            l.endDate = (endDate);
            //"{"deviceId":"118","deviceMacId":"101","startDate":"1505889000","timeZone":19800}"
            // r.method = "post";
            // r.endpoint = "history";
            requestBodyField = JsonConvert.SerializeObject(l);

            HttpResponseMessage response = await httpClient.PostAsync(new Uri(resourceAddress),
                     new HttpStringContent(requestBodyField, Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json"));
            //HttpResponseMessage response = await httpClient.PostAsync(new Uri(resourceAddress),
            //    new HttpStringContent(requestBodyField));
            var linegraphstring = await response.Content.ReadAsStringAsync();
            RootObjectLine rootObj = new RootObjectLine();
            try
            {
                rootObj = JsonConvert.DeserializeObject<RootObjectLine>(linegraphstring);
            }
            catch { }

            return rootObj;
        }
        public class LineRequest
        {
            public string startDate { get; set; }
            public string endDate { get; set; }
            public string deviceMacId { get; set; }
            public string aggregateFunction { get; set; }
        }
        public async Task<IRootObjectLIne> GetLineGraph2(string startDate, string endDate, string devicemacId, string aggregateFunction)
        {



            string requestBodyField = string.Empty; ;

            string timeZone = string.Empty; ;
            TimeSpan t = (new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0)).ToUniversalTime() - new DateTime(1970, 1, 1);
            int secondsSinceEpoch = (int)t.TotalSeconds;
            //startDate = secondsSinceEpoch.ToString();
            //    startDate = "2017-09-26T03:04:00Z";
            //  endDate   = "2017-09-26T05:07:00Z";
            // devicemacId = "5CCF7FA391AB";
            aggregateFunction = "MAX";
            //RequestBodyField=
            var c = new HttpClient();
            var resp = await c.GetAsync(new Uri("http://localhost/CamadoService/CamadoService.svc/LineGraph/" + devicemacId));
            var linegraphstring = await resp.Content.ReadAsStringAsync();
            System.Xml.XmlReader reader = System.Xml.XmlReader.Create(new System.IO.StringReader(linegraphstring));
            reader.Read();
            string linedata = reader.ReadInnerXml();
           

         
            RootObjectLine rootObj = new RootObjectLine();
            try
            {
                rootObj = JsonConvert.DeserializeObject<RootObjectLine>(linedata);
            }
            catch { }

            return rootObj;
        }

    }
}
