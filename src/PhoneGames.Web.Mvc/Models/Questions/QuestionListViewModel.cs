using System.Collections.Generic;
using PhoneGames.Business.Questions;

namespace PhoneGames.Web.Models.Questions
{
    public class QuestionListViewModel
    {
        public IReadOnlyList<QuestionDto> Questions { get; set; }
    }
}