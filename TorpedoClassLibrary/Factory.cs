using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    public static class Factory
    {
        public static IShip CreateShip(int length, Vector2 position, Ship.Orientation orientation)
        {
            if (Checks.IsShipPlaceable(length, position, orientation))
            {
                IShip ship = new Ship(length, position, orientation);
                return ship;
            }
            else
            {
                return null;
            }
        }
        private static Player.IActions CreateActions(IPlayer player)
        {
            return new Actions(player);
        }
        public static IPlayer CreatePlayer(string name)
        {
            IPlayer player = new Player(name);
            player.Actions = CreateActions(player);
            return player;
        }
    }
}
