using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace FlappyServer.Hubs
{
    
    public class dataHub : Hub
    {
        private static Dictionary<string, string> ListUser = new Dictionary<string, string>();
        [HubMethodName("startGame")]
        public async Task StartToPlay(string username)
        {
            ListUser.Add(Context.ConnectionId, username);
        }
        [HubMethodName("UpAction")]
        public async Task UpActionFromClient()
        {
            await Clients.All.SendAsync("UserUp", ListUser[Context.ConnectionId]);
        }
        [HubMethodName("DeadStatus")]
        public async Task deadUser()
        {
            await Clients.All.SendAsync("UserDead", ListUser[Context.ConnectionId]);
        }
    }
}
