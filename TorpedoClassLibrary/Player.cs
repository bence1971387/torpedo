using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    class Player
    {
        public int Score { get; private set; }
        public string Name { get; }
        public Actions Actions { get; }
        public List<Ship> ShipList { get; }
        public void RemoveShip(Ship ship)
        {
            if (ShipList.Contains(ship))
            {
                ShipList.Remove(ship);
            }
        }
        public void AddShip(Ship ship)
        {
            ShipList.Add(ship);
        }
        public void AddToScore(int score)
        {
            Score += score;
        }
        public Player(string getName, Actions getActions)
        {
            Name = getName;
            Actions = getActions;
            Score = 0;
            ShipList = new List<Ship>();
        }
    }
}
