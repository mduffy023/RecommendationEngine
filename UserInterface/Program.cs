using front_end.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace front_end
{
    /// <summary>
    /// Entry point and configuration for the Blazor Server application.
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddRazorPages();            
            builder.Services.AddServerSideBlazor();      
            builder.Services.AddSingleton<WeatherForecastService>(); 
            builder.Services.AddSingleton<DataService>();            // In-memory video history service
            builder.Services.AddCors();                 

            // Register YouTubeService for fetching video metadata
            builder.Services.AddScoped<YouTubeService>();            // Scoped: one instance per HTTP request/Blazor circuit
            builder.Services.AddHttpClient<YouTubeService>(client =>
            {
                // Configure the base address for YouTube Data API calls
                client.BaseAddress = new Uri("https://www.googleapis.com/");
            });

            // Build the WebApplication from the configured builder
            var app = builder.Build();

            // Configure the HTTP middleware pipeline
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error"); // Show custom error page in production
                app.UseHsts();                    // Enforce HTTP Strict Transport Security
            }

            // Apply CORS policy to allow any origin, method, and header
            app.UseCors(options =>
            {
                options
                    .AllowAnyMethod()              // Allow all HTTP methods (GET, POST, etc.)
                    .AllowAnyOrigin()              // Allow requests from any domain
                    .AllowAnyHeader()              // Allow any headers
                    .SetIsOriginAllowed(_ => true) // Permit all origins explicitly
                    .WithMethods("GET, PATCH, DELETE, PUT, POST, OPTIONS"); // Explicit allowed methods
            });

            app.UseHttpsRedirection();    // Redirect HTTP requests to HTTPS
            app.UseStaticFiles();         // Serve static files (css, js, images)
            app.UseRouting();             // Enable endpoint routing

            // Map custom endpoints and Blazor hubs
            EndPoints.TestEndPoint.Map(app);  // Register your own endpoint mappings
            app.MapBlazorHub();               // Map the SignalR hub for Blazor Server
            app.MapFallbackToPage("/_Host");  // Fallback to the Blazor host page for client-side routes

            app.Run();  // Start listening for incoming HTTP requests
        }
    }
}