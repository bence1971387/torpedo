using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    public static class Checks
    {
        private static bool IsTilePlayersRegion(IPlayer player, ITile tile)
        {
            if ((int)tile.Position.X >= 0 && (int)tile.Position.X < Board.Width)
            {
                if ((int)tile.Position.Y >= 0 && (int)tile.Position.Y < Board.Height)
                {
                    foreach (var playerArea in Board.PlayerAreaList)
                    {
                        if (playerArea.Player == player && playerArea.PositionList.Contains(tile))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public static bool IsShipPlaceable(IPlayer player, int length, ITile tile, Ship.Orientation orientation)
        {
            if (IsTilePlayersRegion(player, tile))
            {
                int ShipEndUpDown;
                int ShipEndLeftRight;
                switch (orientation)
                {
                    case Ship.Orientation.Up:
                        ShipEndUpDown = (int)tile.Position.Y - (length - 1);
                        if (ShipEndUpDown >= 0 && ShipEndUpDown < Board.Height)
                        {
                            if (IsTilePlayersRegion(player, Board.Positions[(int)tile.Position.X, ShipEndUpDown]))
                            {
                                return true;
                            }
                        }
                        break;
                    case Ship.Orientation.Down:
                        ShipEndUpDown = (int)tile.Position.Y + (length - 1);
                        if (ShipEndUpDown >= 0 && ShipEndUpDown < Board.Height)
                        {
                            if (IsTilePlayersRegion(player, Board.Positions[(int)tile.Position.X, ShipEndUpDown]))
                            {
                                return true;
                            }
                        }
                        break;
                    case Ship.Orientation.Left:
                        ShipEndLeftRight = (int)tile.Position.X - (length - 1);
                        if (ShipEndLeftRight >= 0 && ShipEndLeftRight < Board.Width)
                        {
                            if (IsTilePlayersRegion(player, Board.Positions[ShipEndLeftRight, (int)tile.Position.Y]))
                            {
                                return true;
                            }
                        }
                        break;
                    case Ship.Orientation.Right:
                        ShipEndLeftRight = (int)tile.Position.X + (length - 1);
                        if (ShipEndLeftRight >= 0 && ShipEndLeftRight < Board.Width)
                        {
                            if (IsTilePlayersRegion(player, Board.Positions[ShipEndLeftRight, (int)tile.Position.Y]))
                            {
                                return true;
                            }
                        }
                        break;
                }
            }
            return false;
        }
    }
}
            /*switch (orientation)
{
    case Ship.Orientation.Up:
        if (((int)tile.Position.Y - length) >= 0)
        {
            foreach (var playerArea in Board.PlayerAreaList)
            {
                if(playerArea.Player == player && playerArea.PositionList.Contains(tile))
                {
                    return true;
                }
            }
        }
        return false;
    case Ship.Orientation.Down:
        if (((int)tile.Position.Y + length) < Board.Height)
        {
            return true;
        }
        else
        {
            return false;
        }
    case Ship.Orientation.Left:
        if (((int)tile.Position.X - length) >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    case Ship.Orientation.Right:
        if (((int)tile.Position.X + length) < Board.Width)
        {
            return true;
        }
        else
        {
            return false;
        }
}*/
        
        
