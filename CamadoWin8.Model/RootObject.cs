using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Contracts.Model
{
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

    public class RootObject:IRootObject
    {
        public int status { get; set; }
        public string message { get; set; }
        public AllGraphData allGraphData { get; set; }
    }
}
