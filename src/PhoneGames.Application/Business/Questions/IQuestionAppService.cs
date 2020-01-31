using Abp.Application.Services;
using PhoneGames.MultiTenancy.Dto;

namespace PhoneGames.Business.Questions
{
    public interface IQuestionAppService : ICrudAppService<QuestionDto>
    {
    }
}

