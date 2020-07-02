using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    public class Player : IPlayer
    {
        public enum Type { AI, Human };
        public IActions Actions { get; set; }
        public Type PlayerType { get; private set; }
        public int Score { get; private set; }
        public string Name { get; private set; }
        public IList<IShip> ShipList { get; private set; }
        public void AddShip(IShip ship)
        {
            ShipList.Add(ship);
            ship.EventShipHit += ShipHit;
            ship.EventShipDestroyed += ShipDestroyed;
        }
        public void AddToScore(int score)
        {
            this.Score += score;
        }
        void ShipHit(object sender, int damage)
        {
            AddToScore(damage);
        }
        void ShipDestroyed(object sender, EventArgs e)
        {
            var ship = (IShip)sender;
            AddToScore(ship.Length);
            ship.EventShipDestroyed -= ShipDestroyed;
            if (ShipList.Contains(ship))
            {
                ShipList.Remove(ship);
            }
        }
        internal Player(string name, Type type)
        {
            PlayerType = type;
            Name = name;
            Score = 0;
            ShipList = new List<IShip>();
            /*for (int i = 0; i < length; i++)
            {

            }*/

        }
        //attackoncoordinate
        //  call ship.hit(damage, coordinate)
    }
}
