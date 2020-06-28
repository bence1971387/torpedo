using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    public sealed class Actions
    {
        delegate void CoordinateSelect(int x, int y);
        event CoordinateSelect EventCoordinateSelect;
        public bool AttackOnCoordinate(Player attackingPlayer, Vector2 position)
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
