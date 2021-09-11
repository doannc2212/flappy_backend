using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FlappyServer.Hubs
{
    
    public class dataHub : Hub
    {
        private static GameManagement gameManager = new GameManagement();

        [HubMethodName("startGame")]
        public async Task StartToPlay(string username)
        {
            gameManager.addUser(username, Context.ConnectionId);
            await Clients.All.SendAsync("Notify", username);
        }

        [HubMethodName("UpAction")]
        public async Task UpActionFromClient()
        {
            await Clients.All.SendAsync("UserUp", gameManager.getUserById(Context.ConnectionId).Name);
        }
        [HubMethodName("DeadStatus")]
        public async Task deadUser()
        {
            await Clients.All.SendAsync("UserDead", gameManager.getUserById(Context.ConnectionId).Name);
        }
        [HubMethodName("ExitGame")]
        public async Task ExitGame()
        {
            gameManager.removeUser(Context.ConnectionId);
            await Clients.All.SendAsync("Notify", gameManager.getUserById(Context.ConnectionId).Name);
        }
        [HubMethodName("CallMap")]
        public async Task MapProcess()
        {
            var map = gameManager.getMapForUser(Context.ConnectionId);
            await Clients.Caller.SendAsync("UpdateMap", map.Top, map.Bottom);
        }
        [HubMethodName("addScore")]
        public async Task ScoreProcess()
        {
            gameManager.addScoreForUser(Context.ConnectionId);
        }
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            gameManager.removeUser(Context.ConnectionId);
            var user = gameManager.getUserById(Context.ConnectionId);
            await Clients.All.SendAsync("Notify", user.Name, user.Score);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
