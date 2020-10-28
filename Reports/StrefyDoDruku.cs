//using Check.Model;
using Check.Reports.Framework;
using GeneratorStref;
using System.Collections.Generic;
using System.Linq;

namespace Check.Reports.Reports
{
    public class StrefyDoDruku : IReport
    {
        public string ReportName => "StrefyDoDruku";

        public IEnumerable<object> Data { get; set; }

        public StrefyDoDruku(IEnumerable<object> data)
        {
            Data = data;
        }
    }
}
