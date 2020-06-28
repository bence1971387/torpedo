using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    public class Player
    {
        public int Score { get; private set; }
        public string Name { get; }
        public Actions Actions { get; }
        public List<Ship> ShipList { get; }
        public void AddShip(Ship ship)
        {
            ShipList.Add(ship);
            ship.EventShipHit += ShipHit;
            ship.EventShipDestroyed += ShipDestroyed;
        }
        private void AddToScore(int score)
        {
            this.Score += score;
        }
        
        public Player(string name, Actions actions)
        {
            Name = name;
            Actions = actions;
            Score = 0;
            ShipList = new List<Ship>();
            
        }
        void ShipHit(object sender, int damage)
        {
            AddToScore(damage);
        }
        void ShipDestroyed(object sender, EventArgs e)
        {
            var ship = (Ship)sender;
            AddToScore(ship.Length);
            ship.EventShipDestroyed -= ShipDestroyed;
            if (ShipList.Contains(ship))
            {
                ShipList.Remove(ship);
            }
        }
        
        //attackoncoordinate
        //  call ship.hit(damage, coordinate)
    }
}
