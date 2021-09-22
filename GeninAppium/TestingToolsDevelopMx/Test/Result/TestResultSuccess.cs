using Newtonsoft.Json;
using Reportium.Model.Util;

namespace Reportium.Test.Result
{
    internal class TestResultSuccess : TestResult
    {
        [JsonProperty]
        public readonly string status = "PASSED";

        public bool IsSuccessful()
        {
            return true;
        }

        public string GetMessage()
        {
            return status;
        }

        public string GetFailureReasonName()
        {
            return "";
        }

        public string GetStatus()
        {
            return status;
        }
		override
		public string ToString()
		{
			return new ToStringBuilder<TestResultSuccess>(this)
				.Append(x => x.status)
				.ToString();
		}

    }
}

