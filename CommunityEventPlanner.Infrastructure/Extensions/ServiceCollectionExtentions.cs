using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CommunityEventPlanner.Domain.Entities;
using CommunityEventPlanner.Application.Interfaces.Repositories;
using CommunityEventPlanner.Infrastructure.DataAccess;
using CommunityEventPlanner.Infrastructure.DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using CommunityEventPlanner.Application.Interfaces.UnitofWork;
using CommunityEventPlanner.Infrastructure.DataAccess.UnitOfWork;

namespace CommunityEventPlanner.Infrastructure.Extensions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders();

          

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IEventBookingRepository, EventBookingRepository>();
            services.AddScoped<ICustomUserLoginRepository, CustomUserLoginRepository>();
            services.AddScoped<IEventAttendeeRepository, EventAttendeeRepository>();
            services.AddScoped<IEventOccurrenceRepository, EventOccurrenceRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
