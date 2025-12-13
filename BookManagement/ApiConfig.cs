using System.Configuration;

public static class ApiConfig
{
    public static string BaseUrl =>
        ConfigurationManager.AppSettings["ApiBaseUrl"];
}