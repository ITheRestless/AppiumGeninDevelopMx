using System;

namespace Reportium.Exceptions
{
    /// <summary>
    /// Reporting Exception
    /// </summary>
    /// <remarks> Special reporting exception </remarks>
    public class ReportiumException: Exception
    {

        public ReportiumException(string msg) : base(msg) {}

        public ReportiumException(string msg, Exception exception) : base(msg, exception) { }

    }
}
