using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TorpedoClassLibrary
{
    internal sealed class Actions : IActions
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
            if(!Checks.IsTilePlayersRegion(Player, attackedTile)){
                //attackedTile.SetDisplay(Tile.DisplayType.Attack); 
                foreach (var playerArea in Board.PlayerAreaList)
                {
                    if (playerArea.Player != Player)
                    {
                        foreach (var tile in playerArea.PositionList)
                        {
                            if (tile == attackedTile)
                            {
                                if (playerArea.Player.ShipList.Any(x => x.PositionList.Contains(attackedTile)))
                                {
                                    IShip ship = playerArea.Player.ShipList.First(x => x.PositionList.Contains(attackedTile));
                                    if (ship.Hit(1, attackedTile))
                                    {
                                        Player.AddToScore(1);
                                        return true;
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    attackedTile.SetDisplay(Tile.DisplayType.Attack);
                                }
                                return true;
                            }
                            
                        }
                    }
                }
                return false;
            }
            return false;
        }
    }
}
