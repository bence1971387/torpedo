using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    class Factory
    {
        public Ship CreateShip(int length, Vector2 position, Ship.Orientation orientation)
        {
            if (Checks.IsShipPlaceable(length, position, orientation))
            {
                Ship ship = new Ship(length, position, orientation);
                return ship;
            }
            else
            {
                throw new Exception("Ship parameters are invalid, or not fitting into the current context.");
            }
        }
        private Actions CreateActions()
        {
            return new Actions();
        }
        public Player CreatePlayer(string name)
        {
            return new Player(name, CreateActions());
        }
    }
}
