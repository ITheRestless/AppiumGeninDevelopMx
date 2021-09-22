using Reportium.Test.Result;
using Reportium.Test;
using System;

namespace Reportium.Client
{
    /// <summary>
    /// Reportium client interface
    /// </summary>
    /// <remarks> All reporting clients implements this interface </remarks>
    public interface DigitalZoomClient
    {

        /// <summary>
        ///  Create a new test execution
        /// </summary>
        /// <param name="name"> Test name </param>
        /// <param name="context"> Testing env context, e.g. CI build number </param>
        void TestStart(string name, ReportingTestContext context);

		/// <summary>
		/// Indicates that the test has stopped and its execution status.
		/// </summary>
		/// <param name="testResult"> Test execution result </param>
		void TestStop(TestResult testResult);


		/// <summary>
		/// Indicates that the test has stopped and its execution status.
		/// </summary>
		/// <param name="testResult"> Test execution result </param>
		/// /// <param name="testContext"> testContext Testing env context, e.g. CI build number</param>
		void TestStop(TestResult testResult, ReportingTestContext testContext);


		/// <summary>
		/// Log a new logical step for the current test, e.g. "Submit shopping cart"
		/// </summary>
		/// <param name="description"> description Step description </param>
		[Obsolete("This method is deprecated, Please use stepStart instead.", false)]
        void TestStep(string description);

        /// <summary>
        /// Log the beginning of a new logical step for the current test, e.g. "Submit shopping cart"
        /// </summary>
        /// <param name="description"> description Step description </param>
        void StepStart(string description);

        /// <summary>
        /// Log the end of the previous test step
        /// </summary>
        /// <param name="description"> description Step description </param>
        void StepEnd(string message = null);

        /// <summary>
        /// Returns the URL to the created online report in Perfecto's reporting solution.
        /// </summary>
        /// <remarks> The report is based on <strong>all</strong> tests that match the current execution context, and is not
        /// limited to a single functional test execution.
        /// </remarks>
        /// <returns> URL to the created online report </returns>
        string GetReportUrl();
    }
}