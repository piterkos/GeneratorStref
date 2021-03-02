//using Check.Core.Settings;
using FastReport;
using FastReport.Export.Image;
//using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.IO;
using System.Text;

namespace Check.Reports.Framework
{
    public class ReportService : IReportService
    {
        private readonly string filePath = @"C://";
        private readonly string reportsFolder = $"c:/Check/Raporty";
        private readonly DateTime czasEgzystencjiProgramu = new DateTime(2021, 4, 15, 2, 2, 2);
       
        public void OrderReport(IReport checkReport, ExportMethod exportMethod)
        {
            if (czasEgzystencjiProgramu < DateTime.Now)
                return;
            //TODO maybe it should be a global setting
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            string reportsFolder = Directory.GetCurrentDirectory();

            checkReport.PrepareDataReport();

            Report report = new Report();

            report.Load(Path.Combine(reportsFolder, $"Reports/{checkReport.ReportName}.frx"));

            if (checkReport.Parameters.Count > 0)
            {
                foreach (var parametr in checkReport.Parameters)
                {
                    report.SetParameterValue(parametr.Key, parametr.Value);
                }
            }

            if (checkReport.Data != null)
            {
                report.RegisterData(checkReport.Data, "Data");
            }

            report.Prepare();

            if (!Directory.Exists(reportsFolder)) Directory.CreateDirectory(reportsFolder);

            using var ms = new MemoryStream();

            var totalPages = (int)report.GetVariableValue("TotalPages");


            switch (exportMethod)
            {
                case ExportMethod.File:
                    PdfDocument doc = new PdfDocument();
                    string dateToReportFileName = "_" + DateAndTime.Now.ToShortDateString() + "_" + DateAndTime.Now.Hour.ToString() + DateAndTime.Now.Minute.ToString() + DateAndTime.Now.Second.ToString();
                    for (int i = 0; i < totalPages; i++)
                    {
                        report.Export(new ImageExport() { Resolution = 120, ImageFormat = ImageExportFormat.Tiff, PageRange = PageRange.Current, CurPage = i + 1 }, ms);
                        doc.Pages.Add(new PdfPage());
                        XGraphics xgr = XGraphics.FromPdfPage(doc.Pages[i]);
                        XImage img = XImage.FromStream(ms);
                        xgr.DrawImage(img, 0, 0);
                        ms.SetLength(0);
                    }

                    doc.Save(Path.Combine(reportsFolder, checkReport.ReportName + dateToReportFileName + ".pdf"));
                    doc.Close();
                    break;
                case ExportMethod.Print:
                    for (int i = 0; i < totalPages; i++)
                    {
                        report.Export(new ImageExport() { Resolution = 300, ImageFormat = ImageExportFormat.Jpeg, PageRange = PageRange.Current, CurPage = i + 1 }, ms);
                        //TODO probably there should be functionality to send multiple images to helper (or test line above without current page)
                        RawPrinterHelper.SendByteToPrinter(ms.ToArray());
                        ms.SetLength(0);
                    }
                    break;
            }
        }
    }
}
