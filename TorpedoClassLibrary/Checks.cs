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
        public static bool IsShipPlaceable(int length, Vector2 position, Ship.Orientation orientation)
        {
            if (position.X >= 0 && position.X < Board.Width)
            {
                if (position.Y >= 0 && position.Y < Board.Height)
                {
                    switch (orientation)
                    {
                        case Ship.Orientation.Up:
                            if (((int)position.Y - length) >= 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        case Ship.Orientation.Down:
                            if (((int)position.Y + length) < Board.Height)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        case Ship.Orientation.Left:
                            if (((int)position.X - length) >= 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        case Ship.Orientation.Right:
                            if (((int)position.X + length) < Board.Width)
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
