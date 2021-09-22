﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reportium.Test.Result
{
    public class TestResultFactory
    {
        /// <summary>
        /// create successful test result object
        /// </summary>
        /// <returns>TestResultSuccess object</returns>
        public static TestResult createSuccess()
        {
            return new TestResultSuccess();
        }

		/// <summary>
		/// Creates a failed test execution result
		/// </summary>
		/// <param name="message">Test failure message </param>
		/// <returns>TestResultFailure object</returns>
		public static TestResult createFailure(string message)
        {
            return new TestResultFailure(message, null, null);
        }

		/// <summary>
		/// Creates a failed test execution result
		/// </summary>
		/// <param name="reason"> Test failure message </param>
		/// <param name="ex"> exceotion thrown caused failuer</param>
		/// <returns>TestResultFailure object</returns>
		/// 
		public static TestResult createFailure(string message, Exception ex)
		{
			return new TestResultFailure(message, ex, null);
		}


		/// <summary>
		/// Creates a failed test execution result
		/// </summary>
		/// <param name="ex"> exceotion thrown caused failuer</param>
		/// <returns>TestResultFailure object</returns>
		/// 
		public static TestResult createFailure(Exception ex)
		{
			return createFailure(null, ex, null);
		}

		/// <summary>
		/// Creates a failed test execution result
		/// </summary>
		/// <param name="ex"> exceotion thrown caused failuer</param>
		///  <param name="failureReason"> test failure reason</param>
		/// <returns>TestResultFailure object</returns>
		/// 
		public static TestResult createFailure(Exception ex, string failureReason)
		{
			return createFailure(null, ex, failureReason);
		}

		/// <summary>
		/// Creates a failed test execution result
		/// </summary>
		/// <param name="message"> Test failure message </param>
		/// <param name="ex"> exceotion thrown caused failuer</param>
		///  <param name="failureReason"> test failure reason</param>
		/// <returns>TestResultFailure object</returns>
		/// 
		public static TestResult createFailure(string message, Exception ex, string failureReason)
		{
			return new TestResultFailure(message, ex, failureReason);
		}

    }




}