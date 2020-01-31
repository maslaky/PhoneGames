using Abp.Application.Services;
using Abp.Authorization;
using Abp.Domain.Repositories;
using PhoneGames.Authorization;

namespace PhoneGames.Business.Questions
{
    [AbpAuthorize(PermissionNames.Pages_Questions)]
    public class QuestionAppService : CrudAppService<Question, QuestionDto>, IQuestionAppService
    {
        public QuestionAppService(IRepository<Question, int> repository) : base(repository)
        {
        }
    }
}