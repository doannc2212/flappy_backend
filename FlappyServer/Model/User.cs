using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlappyServer.Model
{
    public class User
    {
        private string _name;
        private int _mapStatus;
        private int _score;

        public User(string name, int mapStatus, int score)
        {
            _name = name;
            _mapStatus = mapStatus;
            _score = score;
        }

        public string Name { get => _name; set => _name = value; }
        public int MapStatus { get => _mapStatus; set => _mapStatus = value; }
        public int Score { get => _score; set => _score = value; }
    }
}
