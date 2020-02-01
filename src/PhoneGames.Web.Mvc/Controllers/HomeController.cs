using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using PhoneGames.Controllers;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Web.Models;
using Microsoft.EntityFrameworkCore;
using PhoneGames.Business.GameInstances;
using PhoneGames.Business.GameTypes;
using PhoneGames.Utilities;
using PhoneGames.Web.Models.Games;

namespace PhoneGames.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : PhoneGamesControllerBase
    {
        private readonly IRepository<GameInstance, long> _gameInstancesRepository;
        private readonly IRepository<GameType> _gameTypesRepository;

        public HomeController(IRepository<GameInstance, long> gameInstancesRepository,
            IRepository<GameType> gameTypesRepository)
        {
            _gameInstancesRepository = gameInstancesRepository;
            _gameTypesRepository = gameTypesRepository;
        }
        public ActionResult Index()
        {
            return View();
        }
        public virtual async Task<ActionResult> StartGame(string gameType)
        {
            var dbGameType = await _gameTypesRepository
                .GetAll()
                .SingleOrDefaultAsync(x => x.GameName == gameType);
            
            if (dbGameType == null)
                return Json(new AjaxResponse {Error = new ErrorInfo(this.L("error"))});

            var gameCode = RandomHelper.RandomFourLetterString();
            var gameInstance = new GameInstance
            {
                Code = gameCode,
                GameType = dbGameType
            };

            await _gameInstancesRepository.InsertAsync(gameInstance);
            
            return RedirectToAction(dbGameType.GameName,"Game", new
            {
                gameCode,
                isGameOwner = true
            });
        }
	}
}
