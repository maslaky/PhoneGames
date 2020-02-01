using System.ComponentModel.DataAnnotations;
using Abp.Auditing;

namespace PhoneGames.Web.Models.Games
{
    public class GameInstanceViewModel
    {
        [Required]
        public string GameCode { get; set; }

        [Required]
        public string UserName { get; set; }

        public bool IsGameOwner { get; set; }
    }
}
