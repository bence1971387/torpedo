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
        private static IActions CreateActions(IPlayer player)
        {
            return new Actions(player);
        }
        public static IPlayer CreatePlayer(string name, Player.Type type)
        {
            IPlayer humanPlayer = new Player(name, type);
            humanPlayer.Actions = CreateActions(humanPlayer);
            return humanPlayer;
        }
        public static void GeneratePlayerAreaList()
        {
            IList<IPlayerArea> playerAreaList = new List<IPlayerArea>();
            IList<ITile> playerOneTiles = new List<ITile>();
            IList<ITile> playerTwoTiles = new List<ITile>();
            IPlayerArea playerOneArea = new PlayerArea(Board.PlayerList[0],playerOneTiles);
            IPlayerArea playerTwoArea = new PlayerArea(Board.PlayerList[1],playerTwoTiles);
            int half = Board.Width / 2;
            playerAreaList.Add(playerOneArea);
            playerAreaList.Add(playerTwoArea);
            Board.SetPlayerAreaList(playerAreaList);
        }
    }
}
