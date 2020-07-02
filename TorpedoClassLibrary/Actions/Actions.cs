﻿using System;
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
                Rectangle displayAttack = new Rectangle
                {
                    Stroke = Brushes.Black,
                    Fill = Brushes.LightBlue,
                    StrokeThickness = 2,
                    Width = Board.TileWidth,
                    Height = Board.TileHeight
                };
                attackedTile.Display = displayAttack;
                foreach (var playerArea in Board.PlayerAreaList)
                {
                    if (playerArea.Player != Player)
                    {
                        foreach (var tile in playerArea.PositionList)
                        {
                            if (tile == attackedTile)
                            {
                                foreach (var ship in playerArea.Player.ShipList)
                                {
                                    if (ship.PositionList.Contains(attackedTile))
                                    {
                                        ship.Hit(1, attackedTile);
                                        Player.AddToScore(1);
                                        return true;
                                    }
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
