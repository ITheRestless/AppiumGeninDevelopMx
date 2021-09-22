using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Remote;
using Reportium.Exceptions;
using Reportium.Model.Util;

namespace Reportium.Model
{
	/// <summary>
	/// PerfectoExecutionContext
	/// The following properties are optional: Job, Project.
	/// </summary>
	public class BaseExecutionContext
	{

        public Job Job { get; set; }
        public Project Project { get; set; }
        public List<string> ContextTags { get; set; }
        public HashSet<CustomField> CustomFields { get; set; }


        public BaseExecutionContext()
        {

            ContextTags = new List<string>();
            CustomFields = new HashSet<CustomField>();
        }

        public class BuilderBase<T, P>
            where T : BuilderBase<T, P>
            where P : class, new()
        {
            protected P obj;
            protected T _this;
            protected BuilderBase()
            {
                obj = new P();
                _this = (T)this;
            }
            public P Build()
            {
                P result = obj;
                obj = null;
                return result;
            }
        }

        /// <summary>
        /// ExecutionContextBuilder
        /// </summary>
        /// <remarks> Build a PerfectoExecutionContext object using given configuration </remarks>
        public class ExecutionContextBuilder<T, P> : BuilderBase<T, P>
        where T : ExecutionContextBuilder<T, P>
        where P : BaseExecutionContext, new()
        {

            public T WithJob(Job job)
			{
                obj.Job = job;
				return _this;
			}

            public T WithProject(Project project)
			{
                obj.Project = project;
				return _this;
			}

			
			public T WithContextTags(string[] contextTags)
			{
				if (contextTags.Length > 0)
				{
                    obj.ContextTags = contextTags.ToList<string>();
				}
				else
				{
                    obj.ContextTags = new List<string>();
				}
				return _this;
			}

			public T WithCustomFields(ICollection<CustomField> customFields)
			{
				if (customFields != null && customFields.Count > 0)
				{
					foreach (CustomField customField in customFields)
					{
						if (customField != null)
						{
                            obj.CustomFields.Add(customField);
						}
					}
				}
				return _this;
			}

        }
        public class ExecutionContextBuilder : ExecutionContextBuilder<ExecutionContextBuilder, BaseExecutionContext> { }
        

    }
}
