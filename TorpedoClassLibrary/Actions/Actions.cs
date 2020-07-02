using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    public class Actions : IActions
    {
        public IPlayer Player { get; set; }

        //delegate void CoordinateSelect(int x, int y);
        //event CoordinateSelect EventCoordinateSelect;
        public Actions(IPlayer player)
        {
            Player = player;
        }
        public bool AttackOnCoordinate(ITile attackedTile)
        {
            /*foreach (var tile in Board.Positions)
            {
                if (tile == position)
                {
                    foreach (var player in Board.PlayerList)
                    {
                        foreach (var ship in player.ShipList)
                        {
                            if (ship.PositionList.Contains(tile))
                            {
                                ship.Hit(1, tile);
                                Player.AddToScore(1);
                                return true;
                            }
                        }
                    }
                }
            }*/
            foreach(var playerArea in Board.PlayerAreaList)
            {
                if(playerArea.Player != Player)
                {
                    foreach(var tile in playerArea.PositionList)
                    {
                        if(tile == attackedTile)
                        {
                            foreach(var ship in playerArea.Player.ShipList)
                            {
                                if (ship.PositionList.Contains(attackedTile))
                                {
                                    ship.Hit(1, attackedTile);
                                    Player.AddToScore(1);
                                    return true;
                                }
                            }
                            //return true;
                        }
                    }
                }
            }
            return false;
        }

    }
}
