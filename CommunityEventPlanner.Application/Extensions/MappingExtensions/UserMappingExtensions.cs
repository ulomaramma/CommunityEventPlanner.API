using CommunityEventPlanner.Application.Dtos;
using CommunityEventPlanner.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityEventPlanner.Application.Extensions.MappingExtensions
{
    public static class UserMappingExtensions
    {
        public static UserDto ToUserDto(this ApplicationUser user, string token = null)
        {
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = token
            };
        }

        public static void SetToken(this UserDto userDto, string token)
        {
            userDto.Token = token;
        }
    }
}
