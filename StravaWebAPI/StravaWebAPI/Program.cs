
using StravaWebAPI.Models;
using StravaWebAPI.Services;

namespace StravaWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

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
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
