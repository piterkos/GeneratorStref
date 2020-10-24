using System.Collections.Generic;

namespace Check.Reports.Framework
{
    public interface IReport
    {
        IEnumerable<object> Data { get; set; }

        string ReportName { get; }
    }
}
