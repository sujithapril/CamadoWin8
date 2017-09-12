using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            CamadoSer.CamadoServiceClient s = new CamadoSer.CamadoServiceClient();
            //  IEnumerable<CamadoSer.Device> ss = s.GetDevices().ToList();

            abc a = new ConsoleApplication.Program.abc();
            a.method1();
            Console.Read();

        }
        public class abc
        {

            public async void method1()

            {
                var c = new HttpClient();
                var resp = await c.GetAsync(new Uri("http://localhost/CamadoService/CamadoService.svc/Devices"));
                var prod = await resp.Content.ReadAsStringAsync();
                // dynamic cc= JsonConvert.DeserializeObject<def>(prod);
                //Console.WriteLine(cc[0].DeviceId);
                List< def > cvb= JsonConvert.DeserializeObject<List<def>>(prod);
                Console.WriteLine(cvb[0].NickNameXX);

            }
        }

        public class def
        {

            public int DeviceId { get; set; }

            public string DeviceMacId { get; set; }

            public string NickNameXX { get; set; }

            public string Description { get; set; }

        }
    }
}
