using System;
using System.Text;
using cAppsule.Hubs;
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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


namespace cAppsule
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
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new OpenApiInfo() {Title = "Cappsule.WebApi", Version = "v1"});
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference()
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            }
                        },
                        new string[] { }
                    }
                });
            });


            services.AddAuthentication(authenticationOptions =>
                {
                    authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Secret"])),
                        ValidateIssuer = true,
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        ValidateAudience = true,
                        ValidAudience = Configuration["Jwt:Audience"],
                        ValidateLifetime = true
                    };
                });


            //Setting up dependency injection
            //MainDbSeeder
            services.AddScoped<IMainDbSeeder, MainDbSeeder>();
            
            //Security
            services.AddScoped<ISecurityService, SecurityService>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IAuthService, AuthUserService>();
            services.AddScoped<IAuthDbSeeder, AuthDbSeeder>();
            //Users
                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped<IUserService, UserService>();
                
                //Friendships
                services.AddScoped<IFriendshipRepository, FriendshipRepository>();
                services.AddScoped<IFriendshipService, FriendshipService>();
                
                //Capsules
                services.AddScoped<ICapsuleRepository, CapsuleRepository>();
                services.AddScoped<ICapsuleService, CapsuleService>();



                //Setting up DB info
            services.AddDbContext<MainDbContext>(options => { options.UseSqlite("Data Source=main.db"); });

            services.AddDbContext<AuthDbContext>(options => { options.UseSqlite("Data Source=auth_database.db"); });

            services.AddRazorPages();
            services.AddSignalR();
            
            services.AddCors(options =>
            {
                options.AddPolicy("Dev-cors", policy =>
                {
                    policy
                        .WithOrigins("http://localhost:3000/")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();

                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MainDbContext context, AuthDbContext authDbContext, ISecurityService securityService,
            IMainDbSeeder mainDbSeeder, IAuthDbSeeder authDbSeeder)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI();
            }
            app.UseCors(builder =>
                {
                    builder.WithOrigins("http://185.51.76.204:8092")
                        .AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            
            /*
            
            var webSocketOptions = new WebSocketOptions
            {
                KeepAliveInterval = TimeSpan.FromMinutes(2),
            };
            webSocketOptions.AllowedOrigins.Add("http://localhost/");

            app.UseWebSockets(webSocketOptions);
            */
            
            
            mainDbSeeder.SeedDevelopment();
            authDbSeeder.SeedDevelopment();

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); 
                endpoints.MapRazorPages();
                endpoints.MapHub<CapsuleHub>("/friendRequestHub");
            });
        }
    }
}