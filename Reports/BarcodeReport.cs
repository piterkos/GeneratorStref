//using Check.Model;
using Check.Reports.Framework;
using GeneratorStref;
using System.Collections.Generic;
using System.Linq;

namespace Check.Reports.Reports
{
    public class BarcodeReport : IReport
    {
        public string ReportName => "FastReport_Barcode";//"Barcode";

        public IEnumerable<object> Data { get; set; }

        public BarcodeReport(IEnumerable<object> data)
        {
            Data = data;
            ////TODO For testing
            //Data = new List<Strefa>() { new Strefa() { n }, new ScannerDataDto() { EAN = "1234", Zone = "112" } };
        }
    }
}
