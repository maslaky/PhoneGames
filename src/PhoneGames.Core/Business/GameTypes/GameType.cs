using Abp.Domain.Entities.Auditing;

namespace PhoneGames.Business.GameTypes
{
    public class GameType : FullAuditedEntity<int>
    {
        public string GameName { get; set; }
    }
}