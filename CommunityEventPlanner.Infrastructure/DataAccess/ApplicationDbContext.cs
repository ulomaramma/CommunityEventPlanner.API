using CommunityEventPlanner.Domain.Entities;
using CommunityEventPlanner.Domain.Enum;
using CommunityEventPlanner.Infrastructure.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Infrastructure.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<EventBooking> EventBookings { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }
        public DbSet<EventAttendee> EventAttendees { get; set; }
        public DbSet<EventOccurrence> EventOccurrences { get; set; }
        public DbSet<CustomeUserLogin> CustomUserLogins { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Event>()
                .Property(e => e.EventStatus)
                .HasConversion<int>();

            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(iul => new { iul.LoginProvider, iul.ProviderKey });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(iur => new { iur.UserId, iur.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(iut => new { iut.UserId, iut.LoginProvider, iut.Name });

            modelBuilder.Entity<Event>()
                .HasOne(e => e.User)
                .WithMany(u => u.Events)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.NoAction);  // Prevent cascading delete


            modelBuilder.Seed();


        }
        //public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        //{
        //    UpdateAuditFields();
        //    return await base.SaveChangesAsync(cancellationToken);
        //}

        //private void UpdateAuditFields()
        //{
        //    var entries = ChangeTracker.Entries<BaseEntity>();
        //    var currentUserId = Guid.NewGuid().ToString();// this should come from  logged in userId

        //    foreach (var entry in entries)
        //    {
        //        if (entry.State == EntityState.Added)
        //        {
        //            entry.Entity.CreatedBy = currentUserId;
        //            entry.Entity.CreatedDate = DateTime.UtcNow;
        //        }
        //        else if (entry.State == EntityState.Modified)
        //        {
        //            entry.Entity.ModifiedBy = currentUserId;
        //            entry.Entity.ModifiedDate = DateTime.UtcNow;
        //        }
        //    }
        //}
       
        public  async Task SeedUsersAndRoles(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Seed Roles
            if (!roleManager.Roles.Any())
            {
                var roles = new List<string> { "Admin", "User" };

                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Seed Users
            if (!userManager.Users.Any())
            {
                var user = new ApplicationUser
                {
                    UserName = "dan.marley@everflowutilities.com",
                    Email = "dan.marley@everflowutilities.com",
                    FirstName = "Dan",
                    LastName = "Marley",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(user, "P@ssw0rd");

                if (result.Succeeded)
                {
                    // Assign User to Role
                    await userManager.AddToRoleAsync(user, "User");
                }
            }
        }
    }
}
