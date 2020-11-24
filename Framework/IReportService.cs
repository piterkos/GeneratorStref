namespace Check.Reports.Framework
{
    public interface IReportService
    {
        void OrderReport(IReport report, ExportMethod exportMethod);
    }
}
