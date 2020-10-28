using FastReport;
using FastReport.Export.PdfSimple;
using System.IO;

namespace Check.Reports.Framework
{
    public class ReportService : IReportService
    {
        private readonly IReport _report;

        public ReportService(IReport report)
        {
            _report = report;
        }

        public void OrderReport()
        {
            string reportsFolder = Directory.GetCurrentDirectory();

            Report report = new Report();
            report.Load(reportsFolder+@"\Reports\"+_report.ReportName+".frx");//Path.Combine(reportsFolder, $"Reports /{_report.ReportName}.frx"));
            //@"C:\Users\piter\source\repos\piterkos\GeneratorStref\Reports\FastReport_Barcode.frx");
            report.RegisterData(_report.Data, "Data");

            report.Prepare();

            PDFSimpleExport pdfExport = new PDFSimpleExport();

            pdfExport.Export(report, @"C:\Check\Raporty\StrefyDoDruku.pdf");
        }
    }
}
