using System.ComponentModel.DataAnnotations;
using Abp.Auditing;

namespace PhoneGames.Web.Models.Games
{
    public class GameInstanceViewModel
    {
        [Required]
        [DisableAuditing]
        public string GameCode { get; set; }

        public bool IsGameOwner { get; set; }
    }
}
