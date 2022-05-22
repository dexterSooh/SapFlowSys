using SapflowApplication.Helpers;

namespace SapflowApplication
{
    public static class ApiPaths
    {
        public static string BaseUrl { get; } = AppConfiguration.GetAppConfig("BaseUrl");

        public static string Authenticate { get; } = "SapFlow/Authenticate";
        public static string GetCompanySites { get; } = "api/GetCompanySites";

    }
}