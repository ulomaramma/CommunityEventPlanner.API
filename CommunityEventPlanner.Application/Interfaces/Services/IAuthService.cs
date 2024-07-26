using CommunityEventPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<string> GenerateJwtToken(ApplicationUser user);

    }
}
