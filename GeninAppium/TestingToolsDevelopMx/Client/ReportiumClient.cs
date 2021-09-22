using Reportium.Test;
using Reportium.Test.Result;
using System;

namespace Reportium.Client
{
    /// <summary>
    /// Reportium client interface
    /// </summary>
    /// <remarks> All reporting clients implements this interface </remarks>
    public interface ReportiumClient : DigitalZoomClient
    {

        /// <summary>
        /// Adding assertions to the Execution Report. This method will not fail the test
        /// </summary>
        /// <param name="message">Used to label the assertion</param>
        /// <param name="status">Indicates the result of the verification operation</param>
        void ReportiumAssert(string message, bool status);

    }
}
