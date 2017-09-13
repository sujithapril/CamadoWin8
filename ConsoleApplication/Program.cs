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
            a.method2();
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

            public async void method2()
            {

                var c = new HttpClient();
                var resp = await c.GetAsync(new Uri("http://localhost/CamadoService/CamadoService.svc/BarGraph/" + 2));
                var prod = await resp.Content.ReadAsStringAsync();
                // dynamic cc= JsonConvert.DeserializeObject<def>(prod);
                //Console.WriteLine(cc[0].DeviceId);
               
                prod = prod.Replace(Environment.NewLine,string.Empty);
                prod = prod.Replace("\u0009", string.Empty);
                
                var rootObj = JsonConvert.DeserializeObject<RootObject>(prod);
                 ;
            }
        }
        public class GraphSery
        {
            public string name { get; set; }
            public List<string> columns { get; set; }
            public List<List<object>> values { get; set; }
        }

        public class GraphResult
        {
            public List<GraphSery> graphSeries { get; set; }
        }

        public class GraphData
        {
            public List<GraphResult> graphResults { get; set; }
        }

        public class GraphRow
        {
            public int hourlyAverageId { get; set; }
            public int orgId { get; set; }
            public int userId { get; set; }
            public int deviceId { get; set; }
            public int timeFrame { get; set; }
            public DateTime dateCreated { get; set; }
            public DateTime dateUpdated { get; set; }
            public double FA { get; set; }
            public double SA { get; set; }
            public int CA { get; set; }
            public int HA { get; set; }
            public int XA { get; set; }
            public int YA { get; set; }
            public int ZA { get; set; }
            public int count { get; set; }
            public int status { get; set; }
            public string log { get; set; }
        }

        public class AllGraphData
        {
            public GraphData graphData { get; set; }
            public List<GraphRow> graphRows { get; set; }
        }

        public class RootObject
        {
            public int status { get; set; }
            public string message { get; set; }
            public AllGraphData allGraphData { get; set; }
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
