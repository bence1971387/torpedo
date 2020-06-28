using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    public class Ship
    {
        public enum Orientation { Up, Down, Left, Right};
        public int Length { get; set; }
        public int Health { get; set; }
        public List<Tile> PositionList { get; set; }
        public event EventHandler EventShipDestroyed;
        public event EventHandler <int>EventShipHit;
        public event EventHandler <List<Tile>>EventCannotPlaceShip;
        public void Hit(int damage, Tile position)
        {
            EventShipHit(this, damage);
            Health -= damage;
            PositionList.Remove(position);
            if (Health >= 0)
            {
                EventShipDestroyed(this, EventArgs.Empty);
            }
        }
        public static bool IsShipPlaceable(int length, Vector2 position, Orientation orientation)
        {
            if (position.X >= 0 && position.X < Board.width)
            {
                if (position.Y >= 0 && position.Y < Board.height)
                {
                    switch (orientation)
                    {
                        case Orientation.Up:
                            if (((int)position.Y - length) >= 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        case Orientation.Down:
                            if (((int)position.Y + length) < Board.height)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        case Orientation.Left:
                            if (((int)position.X - length) >= 0)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        case Orientation.Right:
                            if (((int)position.X + length) < Board.width)
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
        public Ship(int length, Vector2 position, Orientation orientation)
        {
            this.Length = length;
            this.Health = length;
            switch (orientation)
            {
                case Orientation.Up:
                    break;
                case Orientation.Down:
                    break;
                case Orientation.Left:
                    break;
                case Orientation.Right:
                    break;
                default:
                    break;
            }
        }
    }
}