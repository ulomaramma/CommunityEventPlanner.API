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
namespace CommunityEventPlanner.IntegrationTests
{
    public class IntegrationTestBase:IClassFixture<WebApplicationFactory<Program>>
    {
        protected readonly HttpClient _client;
        protected readonly ApplicationDbContext _context;

        public IntegrationTestBase(WebApplicationFactory<Program> factory)
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("TestDb")
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            _context = new ApplicationDbContext(options);
            SeedData(_context);

            var clientFactory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.RemoveAll(typeof(ApplicationDbContext));
                    services.AddDbContext<ApplicationDbContext>(options =>
                    {
                        options.UseInMemoryDatabase("TestDb");
                    });
                });
            });

            _client = clientFactory.CreateClient();
        }

        private void SeedData(ApplicationDbContext context)
        {
            // Seed initial data for testing
            var hasher = new PasswordHasher<ApplicationUser>();
            var user = new ApplicationUser
            {
                UserName = "testuser",
                Email = "testuser@example.com",
                FirstName = "Test",
                LastName = "User",
                NormalizedEmail = "TESTUSER@EXAMPLE.COM",
                NormalizedUserName = "TESTUSER"
            };
            user.PasswordHash = hasher.HashPassword(user, "Password123!");

            context.Users.Add(user);
            context.SaveChanges();

            context.Events.AddRange(
                new Event
                {
                    Title = "Upcoming Event 1",
                    Description = "This event is in the future.",
                    StartDate = DateTime.UtcNow.AddDays(5),
                    EndDate = DateTime.UtcNow.AddDays(6),
                    StartTime = new TimeSpan(10, 0, 0),
                    EndTime = new TimeSpan(18, 0, 0),
                    Location = "Location B",
                    IsPhysical = false,
                    AccessLink = "https://example.com",
                    IsFree = false,
                    Cost = 50,
                    Capacity = 200
                },
                new Event
                {
                    Title = "Upcoming Event 2",
                    Description = "This event is also in the future.",
                    StartDate = DateTime.UtcNow.AddDays(15),
                    EndDate = DateTime.UtcNow.AddDays(16),
                    StartTime = new TimeSpan(11, 0, 0),
                    EndTime = new TimeSpan(19, 0, 0),
                    Location = "Location C",
                    AccessLink = "https://example.com",
                    IsPhysical = true,
                    IsFree = true,
                    Cost = 0,
                    Capacity = 150
                }
            );

            context.SaveChanges();
        }
    }
}
