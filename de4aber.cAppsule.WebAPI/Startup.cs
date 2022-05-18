using System.Text;
using cAppsule;
using de4aber.cAppsule.Core.IServices;
using de4aber.cAppsule.DataAccess;
using de4aber.cAppsule.DataAccess.Repositories;
using de4aber.cAppsule.Domain.IRepositories;
using de4aber.cAppsule.Domain.Service;
using de4aber.cAppsule.Security;
using de4aber.cAppsule.Security.IRepositories;
using de4aber.cAppsule.Security.IServices;
using de4aber.cAppsule.Security.Repositories;
using de4aber.cAppsule.Security.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Microsoft.OpenApi.Models;


namespace voresgruppe.ThirdSemesterExamBackend.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen();



            //Setting up dependency injection
                //MainDbSeeder
                services.AddScoped<IMainDbSeeder, MainDbSeeder>();

                //Users
                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped<IUserService, UserService>();
                
                //Friendships
                services.AddScoped<IFriendshipRepository, FriendshipRepository>();
                services.AddScoped<IFriendshipService, FriendshipService>();
                
                //Security
                services.AddScoped<IAuthRepository, AuthRepository>();
                services.AddScoped<IAuthService, AuthService>();
                services.AddScoped<IAuthDbSeeder, AuthDbSeeder>();

            
            //Setting up DB info
            services.AddDbContext<MainDbContext>(options => {
                options.UseSqlite("Data Source=main.db");
            });

            services.AddDbContext<AuthDbContext>(options =>
            {
                options.UseSqlite("Data Source=auth.db");
            });
            
            services.AddCors(options =>
            {
                options.AddPolicy("Dev-cors", policy =>
                {
                    policy
                        .WithOrigins("http://localhost:7010")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MainDbContext context, 
            IMainDbSeeder mainDbSeeder)
        {
            new MainDbSeeder(context).SeedDevelopment();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            
                app.UseSwagger();

                app.UseSwaggerUI();
                app.UseCors("Dev-cors");
            }
           
            

            app.UseHttpsRedirection();

            app.UseAuthentication();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}