using Abp.AspNetCore.Mvc.ViewComponents;

namespace PhoneGames.Web.Views
{
    public abstract class PhoneGamesViewComponent : AbpViewComponent
    {
        protected PhoneGamesViewComponent()
        {
            LocalizationSourceName = PhoneGamesConsts.LocalizationSourceName;
        }
    }
}
