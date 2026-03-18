using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StravaWebAPI.Data;
using StravaWebAPI.Models;
using StravaWebAPI.Services;

namespace StravaWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {   
            //https://learn.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-10.0
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
                                  ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is missing.");

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
            }).AddIdentityCookies();

            builder.Services.AddAuthorization();

            builder.Services.Configure<StravaOptions>(builder.Configuration.GetSection("Strava"));
            builder.Services.AddHttpClient();
            builder.Services.AddDataProtection();

            builder.Services.AddScoped<IStravaAuthService, StravaAuthService>();
            builder.Services.AddScoped<IStravaApiService, StravaApiService>();

            var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>()
                                 ?? ["http://localhost:5173", "http://localhost:3000"];

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("ReactApp", policy =>
                {
                    policy.WithOrigins(allowedOrigins)
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseCors("ReactApp");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
