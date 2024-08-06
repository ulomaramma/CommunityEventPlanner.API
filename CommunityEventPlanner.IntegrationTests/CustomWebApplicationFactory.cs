using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Xunit;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using CommunityEventPlanner.Infrastructure.DataAccess;
using CommunityEventPlanner.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
namespace CommunityEventPlanner.IntegrationTests
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected readonly HttpClient _client;
        protected readonly ApplicationDbContext _context;
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Remove the app's ApplicationDbContext registration.
                var descriptor = services.SingleOrDefault(
                    d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Add ApplicationDbContext using an in-memory database for testing.
                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                // Ensure the database is created.
                var sp = services.BuildServiceProvider();
                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<ApplicationDbContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TProgram>>>();

                    db.Database.EnsureCreated();

                    try
                    {
                        // Seed the database with test data.
                       SeedTestData(db, scopedServices.GetRequiredService<UserManager<ApplicationUser>>(), scopedServices.GetRequiredService<RoleManager<IdentityRole>>());
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the database with test data. Error: {Message}", ex.Message);
                    }
                }
            });
        }

        private void SeedTestData(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Seed roles
            var userRole = new IdentityRole("User");
            if (!roleManager.RoleExistsAsync(userRole.Name).Result)
            {
                roleManager.CreateAsync(userRole).Wait();
            }

            // Seed users
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    UserName = "testuser@example.com",
                    Email = "testuser@example.com",
                    FirstName = "Test",
                    LastName = "User",
                    EmailConfirmed = true
                };

                userManager.CreateAsync(user, "Test@123").Wait();
                userManager.AddToRoleAsync(user, "User").Wait();
            }

            // Seed event categories
            if (!context.EventCategories.Any())
            {
                var eventCategory = new EventCategory { Name = "Tech" };
                context.EventCategories.Add(eventCategory);
            }

            // Seed events
            if (!context.Events.Any())
            {
                var eventCategory = context.EventCategories.FirstOrDefault(ec => ec.Name == "Tech");
                var eventItem = new Event
                {
                    Title = "Tech Conference 2024",
                    Description = "Annual tech conference covering the latest in technology.",
                    StartDate = DateTime.UtcNow.AddDays(30),
                    EndDate = DateTime.UtcNow.AddDays(32),
                    StartTime = TimeSpan.FromHours(9),
                    EndTime = TimeSpan.FromHours(17),
                    Location = "New York Convention Center",
                    IsPhysical = true,
                    AccessLink = "",
                    ImageUrl = "",
                    IsFree = false,
                    Cost = 299.99m,
                    Capacity = 500,
                    EventCategory = eventCategory
                };

                context.Events.Add(eventItem);
            }

            context.SaveChanges();
        }

        //private void SeedData(ApplicationDbContext context)
        //{
        //    // Seed initial data for testing
        //    var hasher = new PasswordHasher<ApplicationUser>();
        //    var user = new ApplicationUser
        //    {
        //        UserName = "testuser",
        //        Email = "testuser@example.com",
        //        FirstName = "Test",
        //        LastName = "User",
        //        NormalizedEmail = "TESTUSER@EXAMPLE.COM",
        //        NormalizedUserName = "TESTUSER"
        //    };
        //    user.PasswordHash = hasher.HashPassword(user, "Password123!");

        //    context.Users.Add(user);
        //    context.SaveChanges();

        //    context.Events.AddRange(
        //        new Event
        //        {
        //            Title = "Upcoming Event 1",
        //            Description = "This event is in the future.",
        //            StartDate = DateTime.UtcNow.AddDays(5),
        //            EndDate = DateTime.UtcNow.AddDays(6),
        //            StartTime = new TimeSpan(10, 0, 0),
        //            EndTime = new TimeSpan(18, 0, 0),
        //            Location = "Location B",
        //            IsPhysical = false,
        //            AccessLink = "https://example.com",
        //            IsFree = false,
        //            Cost = 50,
        //            Capacity = 200
        //        },
        //        new Event
        //        {
        //            Title = "Upcoming Event 2",
        //            Description = "This event is also in the future.",
        //            StartDate = DateTime.UtcNow.AddDays(15),
        //            EndDate = DateTime.UtcNow.AddDays(16),
        //            StartTime = new TimeSpan(11, 0, 0),
        //            EndTime = new TimeSpan(19, 0, 0),
        //            Location = "Location C",
        //            AccessLink = "https://example.com",
        //            IsPhysical = true,
        //            IsFree = true,
        //            Cost = 0,
        //            Capacity = 150
        //        }
        //    );

        //    context.SaveChanges();
        //}
    }
}
