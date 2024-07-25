using CommunityEventPlanner.Application.Interfaces.Repositories;
using CommunityEventPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Infrastructure.DataAccess.Repositories
{
    public class CustomUserLoginRepository : GenericRepository<CustomeUserLogin>, ICustomUserLoginRepository
    {
        public CustomUserLoginRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
