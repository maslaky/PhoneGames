using System.Collections.Generic;
using PhoneGames.Roles.Dto;

namespace PhoneGames.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}