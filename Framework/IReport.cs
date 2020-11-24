using System.Collections.Generic;

namespace Check.Reports.Framework
{
    public interface IReport
    {
        IEnumerable<object> Data { get; set; }
        /// <summary>
        /// Słownik pomaga połączyć parametry raportu ze zmiennymi. Wymagana taka sama nazwa
        /// </summary>
        Dictionary<string, object> Parameters { get; set; }
        string ReportName { get; }
        public void PrepareDataReport();
    }
}
