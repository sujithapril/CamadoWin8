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

namespace CamadoWin8.Services.Data
{
    public class GraphService : IGraphService
    {
       

        public async Task<string> GetBarGraph(string deviceId)
        {

            var c = new HttpClient();
            var resp = await c.GetAsync(new Uri("http://localhost/CamadoService/CamadoService.svc/BarGraph/"+ deviceId));
            var prod = await resp.Content.ReadAsStringAsync();
            // dynamic cc= JsonConvert.DeserializeObject<def>(prod);
            //Console.WriteLine(cc[0].DeviceId);
            return prod;
        }
    }
}
