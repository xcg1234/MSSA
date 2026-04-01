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

            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddHttpClient("ServerAPI", client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["ServerBaseAddress"] ?? "https://localhost:7266/");
            });
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ServerAPI"));

            builder.Services.Configure<StravaOptions>(builder.Configuration.GetSection("Strava"));
            // HttpClient is configured above for same-origin API calls from Blazor components.
            builder.Services.AddDataProtection();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddMemoryCache();

            builder.Services.AddScoped<IStravaAuthService, StravaAuthService>();
            builder.Services.AddScoped<IStravaApiService, StravaApiService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.MapControllers();
            app.MapRazorPages();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
            app.Run();
        }
    }
}
