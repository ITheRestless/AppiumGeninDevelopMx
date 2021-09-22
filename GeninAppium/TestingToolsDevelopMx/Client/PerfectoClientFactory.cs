using Reportium.Model;

namespace Reportium.Client
{
    /// <summary>
    /// PerfectoClient Factory
    /// </summary>
    /// <remarks> Create one of the following clients </remarks>
    public static class PerfectoClientFactory
    {
        /// <summary>
        /// Perfecto reporting client 
        /// </summary>
        /// <param name="perfectoExecutionContext"> Context to be attached to the client </param>
        /// <returns> new PerfectoReportingClient object </returns>
        public static ReportiumClient createPerfectoReportiumClient(PerfectoExecutionContext perfectoExecutionContext)
        {
            return new PerfectoReportiumClient(perfectoExecutionContext);
        }
    }
}
