using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;

namespace PhoneGames.Web.Views
{
    public abstract class PhoneGamesRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected PhoneGamesRazorPage()
        {
            LocalizationSourceName = PhoneGamesConsts.LocalizationSourceName;
        }
    }
}
