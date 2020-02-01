using Abp.Domain.Entities.Auditing;
using PhoneGames.Business.GameTypes;

namespace PhoneGames.Business.GameInstances
{
    public class GameInstance : FullAuditedEntity<long>
    {
        public string Code { get; set; }
        public int GameTypeId { get; set; }
        public virtual GameType GameType { get; set; }
    }
}