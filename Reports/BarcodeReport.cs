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

        public BarcodeReport()
        {
            List<Strefa> listaStrefDoDruku = new List<Strefa>();
            for (int i = 0; i < 30; i++)
            {
                string strefa = ((101 + i).ToString()).PadLeft(4, '0');
                listaStrefDoDruku.Add(new Strefa(strefa));
            }
            Data = listaStrefDoDruku;
            ////TODO For testing
            //Data = new List<Strefa>() { new Strefa() { n }, new ScannerDataDto() { EAN = "1234", Zone = "112" } };
        }
    }
}
