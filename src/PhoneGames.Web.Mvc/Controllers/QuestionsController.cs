using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using PhoneGames.Authorization;
using PhoneGames.Business.Questions;
using PhoneGames.Controllers;
using PhoneGames.Users;
using PhoneGames.Web.Models.Users;
using PhoneGames.Users.Dto;
using PhoneGames.Web.Models.Questions;

namespace PhoneGames.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Questions)]
    public class QuestionsController : PhoneGamesControllerBase
    {
        private readonly IQuestionAppService _questionAppService;

        public QuestionsController(IQuestionAppService questionAppService)
        {
            _questionAppService = questionAppService;
        }

        public async Task<ActionResult> Index()
        {
            var questions = (_questionAppService.GetAll(new PagedAndSortedResultRequestDto
                {MaxResultCount = int.MaxValue})).Items;
            
            var model = new QuestionListViewModel()
            {
                Questions = questions
            };
            return View(model);
        }
    }
}
