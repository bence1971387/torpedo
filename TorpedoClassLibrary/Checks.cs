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
        public static bool IsShipPlaceable(int length, ITile tile, Ship.Orientation orientation)
        {
            if (Board.Initialized && tile.Position.X >= 0 && tile.Position.X < Board.Width)
            {
                if (tile.Position.Y >= 0 && tile.Position.Y < Board.Height)
                {
                    switch (orientation)
                    {
                        case Ship.Orientation.Up:
                            if (((int)tile.Position.Y - length) >= 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
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
                    }
                    return true;
                }
                else return false;
            }
            else return false;
        }
    }
}
