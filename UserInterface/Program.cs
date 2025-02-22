using front_end.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace front_end
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<DataService>();
            builder.Services.AddCors();
            builder.Services.AddScoped<YouTubeService>();
            builder.Services.AddHttpClient<YouTubeService>(client =>
            {
                client.BaseAddress = new Uri("https://www.googleapis.com/");
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(options =>
            {
                options.AllowAnyMethod()
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .SetIsOriginAllowed(origin => true)
                            .WithMethods("GET, PATCH, DELETE, PUT, POST, OPTIONS");
            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            EndPoints.TestEndPoint.Map(app);
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            app.Run();         
        }
    }
}