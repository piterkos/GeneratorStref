using Check.Reports.Framework;
using System.Collections.Generic;

namespace Check.Reports.Reports
{
    public class StrefyDoDruku : IReport
    {
        public string ReportName => "StrefyDoDruku";

        public IEnumerable<object> Data { get; set; }
        public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();

        public StrefyDoDruku(IEnumerable<object> data)
        {
            Data = data;
        }

        public void PrepareDataReport()
        {
           
        }
    }
}
