using System;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using Reportium.Test;
using Reportium.Test.Result;
using Reportium.Model;
using Reportium.Exceptions;
using OpenQA.Selenium;

namespace Reportium.Client
{
    /// <summary>
    /// PerfectoReportiumClient
    /// </summary>
    /// <remarks> Implements ReportiumClient interface, this client supports connection via the mcm </remarks>
    public class PerfectoReportiumClient : ReportiumClient
    {

        private PerfectoExecutionContext perfectoExecutionContext; 

        private const string START_TEST_COMMAND = "mobile:test:start";
        private const string START_STEP_COMMAND = "mobile:step:start";
        private const string END_STEP_COMMAND = "mobile:step:end";
        private const string END_TEST_COMMAND = "mobile:test:end";
        private const string ASSERT_COMMAND = "mobile:status:assert";
		private const string MULTIPLE_EXECUTIONS_COMMAND = "mobile:execution:multiple";
		private const string CUSTOM_FIELDS_PARAM_NAME = "customFields";
		private const string TAGS_PARAM_NAME = "tags";
        private const string FAILURE_REASON_PARAM_NAME = "failureReason";
        private const string FAILURE_DESCRIPTION_PARAM_NAME = "failureDescription";
        private const string SUCCESS_PARAM_NAME = "success";

        private const string COMMA = ",";
		private const string EQUALS = "=";


        //Deprecated
        private const string TEST_STEP_COMMAND = "mobile:test:step";



		
        //private string currentTestId;

        /// <summary>
        /// Creates a new instance
        /// </summary>
        /// <param name="PerfectoExecutionContext"> Test execution context details </param>
        public PerfectoReportiumClient(PerfectoExecutionContext perfectoExecutionContext)
        {
            this.perfectoExecutionContext = perfectoExecutionContext;
        }

		/// <summary>
		/// Starting a new test
		/// </summary>
		/// <param name="name"> test's name </param>
		/// <param name="context"> context tags to be attached to this practicular test </param>
		/// <returns> current test id </returns>
		public void TestStart(string name, ReportingTestContext context)
        {
            // Send test-start command
            Dictionary<string, object> param = new Dictionary<string, object>();
            Job job = perfectoExecutionContext.Job;
            if (job != null)
            {
                param.Add("jobName", job.Name);
                param.Add("jobNumber", job.Number);
                param.Add("jobBranch", job.Branch);
            }
            Project project = perfectoExecutionContext.Project;
            if (project != null)
            {
                param.Add("projectName", project.Name);
                param.Add("projectVersion", project.Version);
            }

            param.Add("name", name);
            List<string> tags = new List<string>(perfectoExecutionContext.ContextTags);
            tags.AddRange(context.GetTestExecutionTags());
            param.Add(TAGS_PARAM_NAME, tags);

            List<string> customFieldsPair = new List<string>();
			HashSet<string> existingCustomFields = new HashSet<string>();

			createCustomFieldsParamsValuePairs(context.GetCustomFields(), existingCustomFields, customFieldsPair);
			createCustomFieldsParamsValuePairs(perfectoExecutionContext.CustomFields, existingCustomFields, customFieldsPair);
            param.Add(CUSTOM_FIELDS_PARAM_NAME, customFieldsPair);
		
            ExecuteScript(START_TEST_COMMAND, param);
        }

        /// <summary>
        /// Logical test step
        /// </summary>
        /// <param name="description"> step description </param>
        /// <returns> step execution id </returns>
        [Obsolete("This method is deprecated, Please use stepStart instead.", false)]
        public void TestStep(string description)
        {
            Dictionary <string, object > param = new Dictionary<string, object>();
            param.Add("name", description);
            ExecuteScript(TEST_STEP_COMMAND, param); 
        }

        /// <summary>
        /// Log the beginning of a new logical step for the current test, e.g. "Submit shopping cart"
        /// </summary>
        /// <param name="description"> description Step description </param>
        public void StepStart(string description)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("name", description);
            ExecuteScript(START_STEP_COMMAND, param);
        }

        /// <summary>
        /// Log the end of the previous test step
        /// </summary>
        /// <param name="description"> description Step description </param>
        public void StepEnd(string message = null)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("message", message);
            ExecuteScript(END_STEP_COMMAND, param);
        }

        /// <summary>
        /// Stops the test
        /// </summary>
        /// <param name="testResult"> test result object </param>
        /// <returns>false if failed to execute the test command,
        /// otherwise true. </returns>
        public void TestStop(TestResult testResult)
        {
            //if (currentTestId == null || currentTestId.Equals(""))
            //{
            //    // Short-circuit if previous call to testStart failed
            //    return;
            //}
            //Dictionary<string, object> param = new Dictionary<string, object>();
            //bool isSuccessful = testResult.isSuccessful();
            //param.Add(SUCCESS_PARAM_NAME, isSuccessful);
            //if(!isSuccessful)
            //{
            //    param.Add(FAILURE_REASON_PARAM_NAME, testResult.getMessage());
            //}
            //ExecuteScript(END_TEST_COMMAND, param);
            TestStop(testResult, new ReportingTestContext());

        }

	    public void TestStop(TestResult testResult, ReportingTestContext testContext)
		{

			//if (currentTestId == null || currentTestId.Equals(""))
			//{
			//	// Short-circuit if previous call to testStart failed
			//	return;
			//}
			Dictionary<string, object> param = new Dictionary<string, object>();
            bool isSuccessful = testResult.IsSuccessful();
            param.Add(SUCCESS_PARAM_NAME, isSuccessful);
			if (!isSuccessful)
            {
                
                param.Add(FAILURE_DESCRIPTION_PARAM_NAME, testResult.GetMessage());
                string failureReasonName = testResult.GetFailureReasonName();
                if (!string.IsNullOrEmpty(failureReasonName))
                {
                    param.Add(FAILURE_REASON_PARAM_NAME, failureReasonName);
                }
			}

			if (testContext != null)
			{

				ICollection<string> testExecutionTags = testContext.GetTestExecutionTags();
                if (testExecutionTags != null && testExecutionTags.Count > 0)
				{
					List<String> tags = new List<string>(testExecutionTags);
                    param.Add(TAGS_PARAM_NAME, tags);
				}

				ICollection<CustomField> customFields = testContext.GetCustomFields();
                if (customFields != null && customFields.Count > 0)
				{
					List<string> customFieldsPair = new List<string>();
					createCustomFieldsParamsValuePairs(customFields, new HashSet<string>(), customFieldsPair);
                    param.Add(CUSTOM_FIELDS_PARAM_NAME, customFieldsPair);
				}
			}

			ExecuteScript(END_TEST_COMMAND, param);
		}

        /// <summary>
        /// Get the report
        /// </summary>
        /// <returns> string representation of the report url </returns>
        public string GetReportUrl()
        {
			IWebDriver webDriver = perfectoExecutionContext.GetWebDriver();
			if (!(webDriver is IHasCapabilities)) {
				// Driver is expected to have capabilities to run via Perfecto grid.
				throw new ReportiumException("WebDriver instance is assumed to have Selenium Capabilities");
			}

            Object value = ((IHasCapabilities)webDriver).Capabilities.GetCapability(Constants.Capabilities.executionReportUrl);
			if (value == null)
			{
				return null;
			}

			return Convert.ToString(value) ;

        }

        /// <summary>
        /// script execution
        /// </summary>
        /// <param name="script"> script to excecute </param>
        /// <param name="param"> parameters </param>
        /// <returns> script execution id </returns>
        private void ExecuteScript(string script, Dictionary<string, object> param)
        {
            IWebDriver webdriver = perfectoExecutionContext.GetWebDriver();
            ((IJavaScriptExecutor)webdriver).ExecuteScript(script, param);

        }

        /// <summary>
        /// Adding assertions to the Execution Report. This method will not fail the test
        /// </summary>
        /// <param name="message">Used to label the assertion</param>
        /// <param name="status">Indicates the result of the verification operation</param>
        public void ReportiumAssert(string message, bool status)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param.Add("message", message);
            param.Add("status", status);
            ExecuteScript(ASSERT_COMMAND, param);
        }


        private void createCustomFieldsParamsValuePairs(ICollection<CustomField> populatedCustomFields,
												   HashSet<string> currentCustomFieldsNames,
												   List<string> pairs)
		{
			if (pairs == null)
			{
				return;
			}

			if (currentCustomFieldsNames == null)
			{
				currentCustomFieldsNames = new HashSet<string>();
			}

			foreach (CustomField customField in populatedCustomFields)
			{
                string value = string.IsNullOrEmpty(customField.Value) ? "" : customField.Value;
				string name = customField.Name;
				if (string.IsNullOrEmpty(name))
				{
					throw new ReportiumException("Custom field name cannot be empty");
				}
				if (!currentCustomFieldsNames.Contains(name))
					pairs.Add(name + EQUALS + value);
				currentCustomFieldsNames.Add(name);
			}
		}
    }
}
