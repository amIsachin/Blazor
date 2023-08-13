using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence;

public static class DataBaseConnection
{
    /// <summary>
    /// This class is static it cannot be instiated, This class responsible for get connection string from Blazor data base.
    /// </summary>
    /// <returns></returns>
    public static string GetConnectionString()
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        if (builder.Build().GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value is null)
        {
            return "Error occured while fetching the connection string";
        }

        return builder.Build().GetSection("ConnectionStrings").GetSection("EmployeeConnection").Value;

    }
}