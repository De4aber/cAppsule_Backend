using cAppsule;
using de4aber.cAppsule.Core.IServices;
using de4aber.cAppsule.DataAccess;
using de4aber.cAppsule.DataAccess.Repositories;
using de4aber.cAppsule.Domain.IRepositories;
using de4aber.cAppsule.Domain.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}