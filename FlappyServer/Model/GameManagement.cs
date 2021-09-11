using FlappyServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlappyServer
{
    public class GameManagement
    {
        private Dictionary<string, User> listOfUser;
        private List<MapInGame> lstMap;
        public GameManagement()
        {
            listOfUser = new Dictionary<string, User>();
            lstMap = new List<MapInGame>();
            lstMap.Add(new MapInGame(70));
        }

        public User getUserById(string id)
        {
            return listOfUser[id];
        }

        public MapInGame getMapForUser(string id)
        {
            var statusMapOfUser = listOfUser[id].MapStatus;
            listOfUser[id].MapStatus += 1;
            if(statusMapOfUser == lstMap.Count)
            {
                lstMap.Add(new MapInGame(70));
            }
            return lstMap[statusMapOfUser];
        }
        public void addUser(string name, string id)
        {
            User value = new User(name, 0,0);
            listOfUser.Add(id, value);
        }
        public void removeUser(string id)
        {
            if (listOfUser.Count == 1)
            {
                lstMap.RemoveAll(map => map != null);
            }
            listOfUser.Remove(id);
        }

        public void addScoreForUser(string id)
        {
            if(listOfUser[id] != null)
            listOfUser[id].Score += 1;
        }
    }
}
