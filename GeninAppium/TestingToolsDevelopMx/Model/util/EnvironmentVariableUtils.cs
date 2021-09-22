using System;
namespace Reportium.Model.Util
{
    public class EnvironmentVariableUtils
    {
		public static String GetEnvironmentVariable(params string[] variableNames)
		{
			string result = null;
			foreach (string variableName in variableNames)
			{
                result = Environment.GetEnvironmentVariable(variableName);
				//if (string.IsNullOrEmpty(result))
				//{
				//	result = Environment.(variableName);
				//	result = .getenv(propertyName);
				//}
				if (!string.IsNullOrEmpty(result))
				{
					break;
				}
			}
			return result;
		}
    }
}
