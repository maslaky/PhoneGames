using System;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.Auditing;
using Abp.Domain.Repositories;
using Abp.RealTime;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PhoneGames.Business.GameInstances;
using PhoneGames.Business.GameTypes;

namespace PhoneGames.Web.Hubs
{
    public class AnswerRepairHub : AbpCommonHub
    {
        private readonly IRepository<GameInstance, long> _gameInstancesRepository;
        private readonly IRepository<GameType> _gameTypesRepository;

        public AnswerRepairHub(IRepository<GameType> gameTypesRepository, 
            IRepository<GameInstance, long> gameInstancesRepository,
            IOnlineClientManager onlineClientManager,
            IClientInfoProvider clientInfoProvider)
            : base(onlineClientManager, clientInfoProvider)
        {
            _gameTypesRepository = gameTypesRepository;
            _gameInstancesRepository = gameInstancesRepository;
        }
        
        public async Task CreateGame(string gameCode)
        {
            var userId = AbpSession.UserId;
            var gameInstance = _gameInstancesRepository
                .GetAll()
                .SingleOrDefaultAsync(_ => _.Code == gameCode && _.CreatorUserId == userId);
            

            if (gameInstance == null)
            {
                await Clients.Caller.SendAsync("InvalidGameCode");
            }
            
            await Groups.AddToGroupAsync(Context.ConnectionId, gameCode);
            await Clients.Group(gameCode).SendAsync("CreatedGame", gameCode);
        }

        public async Task JoinGame(string gameCode, string userName)
        {
            var connectionId = Context.ConnectionId;
            var gameInstance = _gameInstancesRepository
                .GetAll()
                .SingleOrDefaultAsync(_ => _.Code == gameCode);

            if(gameInstance == null)
                await Clients.Caller.SendAsync("InvalidGameCode");

            await Groups.AddToGroupAsync(Context.ConnectionId, gameCode);
            await Clients.Group(gameCode).SendAsync("JoinedGame", gameCode, userName, connectionId);
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
               
        }
    }
}