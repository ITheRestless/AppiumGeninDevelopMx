namespace Reportium.Client
{
    /// <summary>
    /// Constants class
    /// </summary>
    internal class Constants
    {
        internal const string  baseReportiumPath = "/test-execution-management-webapp/rest/";

        internal abstract class SDK
        {

			internal const string tagsParameterNameV1 = "reportium-tags";
			internal const string tagsParameterNameV2 = "ReportiumTags";

            internal const string customFieldsParameterName = "ReportiumCustomFields";

            //job properties for missing properties
			internal const string jobNumberParameterNameV1 = "reportium-job-number";
			internal const string jobNumberParameterNameV2 = "ReportiumJobNumber";
			internal const string jobNameParameterNameV1 = "reportium-job-name";
			internal const string jobNameParameterNameV2 = "ReportiumJobName";
			internal const string jobBranchParameterBranchV1 = "reportium-job-branch";
			internal const string jobBranchParameterBranchV2 = "ReportiumJobBranch";

            //project properties for missing properties

			internal const string projectVersionParameterNameV1 = "reportium-project-version";
			internal const string projectVersionParameterNameV2 = "ReportiumProjectVersion";
			internal const string projectNameParameterNameV1 = "reportium-project-name";
			internal const string projectNameParameterNameV2 = "ReportiumProjectName";

            internal const string connectionUriParameterName = "reportium-connection-uri";
            internal const string connectionApiKeyParameterName = "reportium-connection-api-key";
            internal const string connectionTenantParameterName = "reportium-connection-tenant";
        }

        internal abstract class Capabilities
        {
            internal const string executionReportUrl = "testGridReportUrl";
            internal const string executionId = "executionId";
          
        }

        internal abstract class URL
        { 
              //Path format
            internal const string path = "/auth/realms/{0}/protocol/openid-connect/token";

            public class V1
            {
                internal const string v1Path = baseReportiumPath + "v1/";
                internal const string testsResource = v1Path + "test-execution-management/";
                internal const string stepsResource = testsResource + "{0}/steps/"; // This string is formatted with the current test id
            }

            public class QueryParameterNames
            {
                internal const string tenantId = "TENANTID";
                internal const string tags = "tags";
                internal const string externalId = "externalId";
            }
        }

        //internal abstract class UpstreamServer
        //{
        //    internal const string reportingServer = "https://reporting.perfectomobile.com";
        //    internal const string ssoServer = "https://auth.perfectomobile.com";
        //}

    }
}
