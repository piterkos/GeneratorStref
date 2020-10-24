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
            report.Load(@"C:\Users\Aga\source\repos\GeneratorStref\Reports\FastReport_Barcode.frx");//Path.Combine(reportsFolder, $"Reports /{_report.ReportName}.frx"));
            
            report.RegisterData(_report.Data, "Data");

            report.Prepare();

            PDFSimpleExport pdfExport = new PDFSimpleExport();

            pdfExport.Export(report, "Simple List.pdf");
        }
    }
}
