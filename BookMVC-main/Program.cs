using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Book_Assignment3.Data;
using Book_Assignment3.Models;

namespace Book_Assignment3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create a new instance of WebApplicationBuilder
            var builder = WebApplication.CreateBuilder(args);

            // Add DbContext to the service container
            builder.Services.AddDbContext<BookMVCContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BookMVCContext") ?? throw new InvalidOperationException("Connection string 'BookMVCContext' not found.")));

            // Add controllers and views to the service container
            builder.Services.AddControllersWithViews();

            // Build the application
            var app = builder.Build();

            // Configure middleware pipeline

            // If not in development environment, configure error handling and HSTS
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            // Redirect HTTP requests to HTTPS
            app.UseHttpsRedirection();
            // Serve static files
            app.UseStaticFiles();
            // Enable routing
            app.UseRouting();
            // Enable authorization
            app.UseAuthorization();

            // Define controller route
            app.MapControllerRoute(
                name: "default", // Route name
                pattern: "{controller=Books}/{action=Index}/{id?}" // Default pattern
            );

            // Create a scope for service provider
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                // Seed the database with initial data
                SeedData.Initialize(services);
            }

            // Run the application
            app.Run();
        }
    }
}
