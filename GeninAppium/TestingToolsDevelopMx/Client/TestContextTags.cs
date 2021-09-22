using System.Collections.Generic;

namespace Reportium.test
{
    /// <summary>
    ///  Class denoting the test context
    /// </summary>
    /// <remarks> e.g. one or all of the following: test suite, CI build number, SCM branch name, ... </remarks>
    public class TestContextTags
    {
        private List<string> testExecutionTags;

        /// <summary>
        /// Creates a TestContextTags object
        /// </summary>
        /// <param name="testExecutionTags"> One or more strings represents a test tags. </param>
        public TestContextTags(params string[] testExecutionTags)
        {
            this.testExecutionTags = new List<string>(testExecutionTags);
        }

        /// <summary>
        /// Get test tags
        /// </summary>
        /// <returns> List of the given tags </returns>
        public List<string> getTestExecutionTags()
        {
            return testExecutionTags;
        }
    }
}
