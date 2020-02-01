using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhoneGames.Controllers;
using PhoneGames.Web.Models.Games;

namespace PhoneGames.Web.Controllers
{
    public class GameController : PhoneGamesControllerBase
    {
        public IActionResult AnswerRepair(string gameCode, bool isGameOwner)
        {
            var gameInstanceViewModel = new GameInstanceViewModel()
            {
                GameCode = gameCode,
                IsGameOwner = isGameOwner
            };

            return View("AnswerRepair", gameInstanceViewModel);
        }
    }
}