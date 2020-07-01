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
        public IActions Actions { get; set; }
        public interface IActions
        {
            IPlayer Player { get; set; }
            string aaName();
            bool AttackOnCoordinate(IPlayer attackingPlayer, Vector2 position);
        }

        public int Score { get; private set; }
        public string Name { get; }
        public IList<IShip> ShipList { get; }
        public void AddShip(IShip ship)
        {
            ShipList.Add(ship);
            ship.EventShipHit += ShipHit;
            ship.EventShipDestroyed += ShipDestroyed;
        }
        private void AddToScore(int score)
        {
            this.Score += score;
        }

        internal Player(string name)
        {

            Name = name;
            Score = 0;
            ShipList = new List<IShip>();

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

        //attackoncoordinate
        //  call ship.hit(damage, coordinate)
    }
}
