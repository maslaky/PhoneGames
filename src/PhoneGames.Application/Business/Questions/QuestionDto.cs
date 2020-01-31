using Abp.Application.Services.Dto;
using Abp.AutoMapper;

namespace PhoneGames.Business.Questions
{
    [AutoMap(typeof(Question))]
    public class QuestionDto : FullAuditedEntityDto<int>
    {
        public string Text { get; set; }
    }
}