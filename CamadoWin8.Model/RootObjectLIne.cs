using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamadoWin8.Contracts.Model
{
    public class LineSeries
    {
        public string name { get; set; }
        public List<string> columns { get; set; }
        public List<List<object>> values { get; set; }
    }

    public class LineResult
    {
        public int statement_id { get; set; }
        public List<LineSeries> series { get; set; }
    }

    public class RootObjectLine:IRootObjectLIne
    {
        public List<LineResult> results { get; set; }
    }
}
