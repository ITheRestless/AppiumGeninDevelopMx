﻿﻿using System;
using Newtonsoft.Json;
using Reportium.Model.Util;

namespace Reportium.Test.Result
{
    /// <summary>
    /// Test result failure
    /// </summary>
    internal class TestResultFailure : TestResult
    {

		public static readonly int MESSAGE_MAX_LENGTH = 4096;
		public static readonly string TRIMMED_TEXT_SUFFIX = "...";

		private string message;
		private string failureReasonName;

        [JsonProperty]
        public readonly string status = "FAILED";

        internal TestResultFailure(string reason, Exception ex, string failureReasonName)
        {

            this.failureReasonName = failureReasonName;

            if (ex != null)
            {
                this.message = reason + ". Stack Trace:" + ex.StackTrace;
            }
            else
            {
                this.message = reason;
            }

            if (message != null && message.Length > MESSAGE_MAX_LENGTH)
			{
                message = message.Substring(0, MESSAGE_MAX_LENGTH - TRIMMED_TEXT_SUFFIX.Length) + TRIMMED_TEXT_SUFFIX;
			}
        }

        public string GetMessage()
        {
            return message;
        }

		public string GetFailureReasonName()
		{
			return failureReasonName;
		}

        public bool IsSuccessful()
        {
            return false;
        }

        public string GetStatus()
        {
            return status;
        }

        override
        public string ToString()
        {
			return new ToStringBuilder<TestResultFailure>(this)
				.Append(x => x.message)
                .Append(x => x.status)
                .Append(x => x.failureReasonName)
                .ToString();
        }
    }
}