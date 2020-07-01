using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    internal class Actions : Player.IActions
    {
        public IPlayer Player { get; set; }

        //delegate void CoordinateSelect(int x, int y);
        //event CoordinateSelect EventCoordinateSelect;
        public Actions(IPlayer player)
        {
            Player = player;
        }
        public string aaName()
        {
            return Player.Name;
        }
        public bool AttackOnCoordinate(IPlayer attackingPlayer, Vector2 position)
        {
            foreach (var tile in Board.Positions)
            {
                if (tile.Position == position)
                {
                    foreach (var player in Board.PlayerList)
                    {
                        foreach (var ship in player.ShipList)
                        {
                            if (ship.PositionList.Contains(tile))
                            {
                                ship.Hit(1, tile);
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

    }
}
