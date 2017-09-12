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
       

        public async Task<IEnumerable<IDeviceInfo>> GetDeviceList()
        {

            var c = new HttpClient();
            var resp = await c.GetAsync(new Uri("http://localhost/CamadoService/CamadoService.svc/Devices"));
            var prod = await resp.Content.ReadAsStringAsync();
            // dynamic cc= JsonConvert.DeserializeObject<def>(prod);
            //Console.WriteLine(cc[0].DeviceId);
            List<DeviceInfo> deviceinfoList = JsonConvert.DeserializeObject<List<DeviceInfo>>(prod);
           

            return deviceinfoList.AsEnumerable();
        }
    }
}
