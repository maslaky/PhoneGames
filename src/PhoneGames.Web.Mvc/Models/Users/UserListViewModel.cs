using System.Collections.Generic;
using PhoneGames.Roles.Dto;
using PhoneGames.Users.Dto;

namespace PhoneGames.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}
