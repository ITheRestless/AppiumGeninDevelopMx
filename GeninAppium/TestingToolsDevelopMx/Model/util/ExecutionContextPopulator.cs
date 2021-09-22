using System;
using System.Collections.Generic;
using Reportium.Exceptions;
using static Reportium.Client.Constants.SDK;

namespace Reportium.Model.Util
{

    /// <summary>
    /// Service for automatically updating missing details in <see cref="Job"/> and <see cref="Project"/>
    /// instances from environment variables
    /// </summary>
    class ExecutionContextPopulator
    {

		public static readonly string INVALID_ENV_CUSTOM_FIELD_ERROR = "Failed to parse custom fields parameter: '%s'";

        private static readonly char COMMA = ',';
		public static readonly char EQUALS = '=';

        /// <summary>
        /// Returns a new {@link Job} with the same properties as the given source.
        /// </summary>
        /// <remarks>
        /// If the source is missing some properties then this method will try to get values for
        /// them based on well-defined environment variable names.
        /// </remarks>
        /// <param name="src"> job source </param>
        /// <returns0><code>null</code> if the interpolated job name is empty </returns>
        public static Job PopulateMissingJobPropertiesFromEnvVariables(Job src)
        {
            Job target = new Job();

            // Copy initial values
            if (src != null)
            {
                target.Number = src.Number;
                target.Name = src.Name;
                target.Branch = src.Branch;
            }

			// Fill missing properties from environment variables
			if (target.Number == 0)
			{
                string variable = EnvironmentVariableUtils.GetEnvironmentVariable(jobNumberParameterNameV2, jobNumberParameterNameV1);
                if (!string.IsNullOrEmpty(variable))
				{
                    target.Number = (int.Parse(variable));
				}
			}

			if (string.IsNullOrEmpty(target.Branch))
			{
				string variable = EnvironmentVariableUtils.GetEnvironmentVariable(jobBranchParameterBranchV2, jobBranchParameterBranchV1);
				if (!string.IsNullOrEmpty(variable))
				{
                    target.Branch = variable;
				}
			}

            if (string.IsNullOrEmpty(target.Name))
			{
				string variable = EnvironmentVariableUtils.GetEnvironmentVariable(jobNameParameterNameV2, jobNameParameterNameV1);
                target.Name = variable;
			}

			if (string.IsNullOrEmpty(target.Name))
			{
				return null;
			}
			return target;
        }

        /// <summary>
        /// Returns a new <see cref="Project"/> with the same properties as the given source.
        /// </summary>
        /// <remarks> If the source is missing some properties then this method will try to get values for
        /// them based on well-defined environment variable names.
        /// </remarks>
        /// <param name="src"> project source </param>
        /// <returns> <code>null</code> if the interpolated project name is empty </returns>
        public static Project PopulateMissingProjectPropertiesFromEnvVariables(Project src)
        {

            Project target = new Project();

            // Copy initial values
            if (src != null)
            {
                target.Version = src.Version;
                target.Name = src.Name;
            }

            // Fill missing properties from environment variables
            if (string.IsNullOrEmpty(target.Version))
            {
                target.Version = EnvironmentVariableUtils.GetEnvironmentVariable(projectVersionParameterNameV2, projectVersionParameterNameV1);
            }

            if (string.IsNullOrEmpty(target.Name))
            {
                target.Name = EnvironmentVariableUtils.GetEnvironmentVariable(projectNameParameterNameV2, projectNameParameterNameV1);
            }

            if (string.IsNullOrEmpty(target.Name))
            {
                return null;
            }
            return target;
        }

		/// <summary>
		/// Returns a new Set&lt;{@link CustomField}&gt; with both properties as the given source and processed values
		/// from a set of predefined environment variables.
		/// If the source is missing some properties then this method will try to get values for
		/// them based on well-defined environment variable names.
		/// In case of name duplication the src will be preferred.
		/// </summary>
        /// /// <param name="src"> CustomField </param>
        /// <returns> <code>new Set&lt;CustomField&l</code> based on both give src and env variables </returns>

		public static HashSet<CustomField> PopulateMissingCustomFieldsPropertiesFromEnvVariables(HashSet<CustomField> src)
		{
			HashSet<CustomField> target = new HashSet<CustomField>();

			string variable = EnvironmentVariableUtils.GetEnvironmentVariable(customFieldsParameterName);
			HashSet<string> variablesNames = new HashSet<string>();

            if (!string.IsNullOrEmpty(variable))
			{
                string[] customFieldsArray = variable.Split(COMMA);

				foreach (string item in customFieldsArray)
				{
					string it = item.Trim();
                    if (string.IsNullOrEmpty(it) || !it.Contains(EQUALS.ToString()))
					{
						throw new ReportiumException(string.Format(INVALID_ENV_CUSTOM_FIELD_ERROR, variable));
					}
					string[] nameAndValue = item.Split(EQUALS);
					string name = nameAndValue[0].Trim();
                    string value = nameAndValue.Length > 1 ? nameAndValue[1].Trim() : null;
					target.Add(new CustomField(name, value));
					variablesNames.Add(name);
				}
			} 

			if (src != null)
			{
				foreach (CustomField customField in src)
				{
					if (!variablesNames.Contains(customField.Name))
					{
						target.Add(customField);
					}
				}
			}

			return target;
		}

        /// <summary>
        /// Returns a new <see cref="Connection"/> based on well-defined environment variable names.
        /// </summary>
        /// <returns>  New connection based on well-defined environment variable names. </returns>
        public static Connection PopulateConnectionFromEnvVariables()
        {
            // Populate connection details
            string apiKey = Environment.GetEnvironmentVariable(connectionApiKeyParameterName);
            string tenant = Environment.GetEnvironmentVariable(connectionTenantParameterName);

            return new Connection(apiKey, tenant);
        }


    }
}
