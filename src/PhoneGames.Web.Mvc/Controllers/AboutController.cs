using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using PhoneGames.Controllers;

namespace PhoneGames.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : PhoneGamesControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
