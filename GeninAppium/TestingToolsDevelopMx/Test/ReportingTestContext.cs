using System.Collections.Generic;
using System.Collections.ObjectModel;
using Reportium.Model;
using Reportium.Model.Util;

namespace Reportium.Test
{
    /**
	 * Class denoting the test context, e.g. one or all of the following: test suite, CI build number, SCM branch name, ...
	 */
    public class ReportingTestContext
	{

		internal readonly List<string> testExecutionTags;
        internal readonly HashSet<CustomField> customFields;

		public ReportingTestContext(params string[] testExecutionTags)
		{
	        if (testExecutionTags != null && testExecutionTags.Length > 0)
			{
				List<string> tags = new List<string>();

				foreach (string tag in testExecutionTags)
				{
					if (!string.IsNullOrEmpty(tag))
					{
						tags.Add(tag);
					}
				}
                this.testExecutionTags = tags; 
			}
			else
			{
                this.testExecutionTags = new List<string>();
			}
            this.customFields = new HashSet<CustomField>();
		}
       
		protected ReportingTestContext(Builder builder)
		{
			this.testExecutionTags = builder.testExecutionTags;
			this.customFields = ExecutionContextPopulator.PopulateMissingCustomFieldsPropertiesFromEnvVariables(builder.customFields);
		}

		public List<string> GetTestExecutionTags()
		{
			return testExecutionTags;
		}

		public HashSet<CustomField> GetCustomFields()
		{
			return customFields;
		}

		public class Builder {

            internal List<string> testExecutionTags;
		    internal HashSet<CustomField> customFields;

			public Builder()
			{
				this.testExecutionTags = new List<string>();
				this.customFields = new HashSet<CustomField>();
			}

			public Builder(ReportingTestContext copy)
			{
				this.testExecutionTags = copy.testExecutionTags;
				this.customFields = copy.customFields;
			}

			public Builder WithTestExecutionTags(Collection<string> testExecutionTags)
			{
				if (testExecutionTags != null && testExecutionTags.Count > 0)
				{
					foreach (string testExecutionTag in testExecutionTags)
					{
                        if (!string.IsNullOrEmpty(testExecutionTag))
						{
							this.testExecutionTags.Add(testExecutionTag);
						}
					}
				}
				return this;
			}

			public Builder WithTestExecutionTags(params string[] testExecutionTags)
			{
				if (testExecutionTags != null)
				{
					WithTestExecutionTags(new Collection<string>(testExecutionTags));
				}
				return this;
			}

            public Builder WithCustomFields(HashSet<CustomField> customFields)
			{
                if (customFields != null && customFields.Count > 0)
				{
					foreach (CustomField customField in customFields)
					{
						if (customField != null)
						{
							this.customFields.Add(customField);
						}
					}
				}
				return this;
			}

			public Builder WithCustomFields(params CustomField[] customFields)
			{
				if (customFields != null)
				{
                    WithCustomFields(new HashSet<CustomField>(customFields));
				}
				return this;
			}

			public ReportingTestContext Build()
			{
				return new ReportingTestContext(this);
			}
		}

		override
		public string ToString()
		{
		    return new ToStringBuilder<ReportingTestContext>(this)
		            .Append(x => x.testExecutionTags)
		            .Append(x => x.customFields)
		            .ToString();
		}
	}
}
