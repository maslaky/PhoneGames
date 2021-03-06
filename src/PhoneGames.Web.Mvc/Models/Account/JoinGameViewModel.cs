﻿using System.ComponentModel.DataAnnotations;
using Abp.Auditing;

namespace PhoneGames.Web.Models.Account
{
    public class JoinGameViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string GameCode { get; set; }
    }
}
