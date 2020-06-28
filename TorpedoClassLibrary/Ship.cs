using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    public class Ship
    {
        public enum Orientation { Up, Down, Left, Right };
        public int Length { get; set; }
        public int Health { get; set; }
        public List<Tile> PositionList { get; set; }
        public event EventHandler EventShipDestroyed;
        public event EventHandler<int> EventShipHit;
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

        public Ship(int length, Vector2 position, Orientation orientation)
        {
            Length = length;
            Health = length;
            switch (orientation)
            {
                case Orientation.Up:
                    for (int i = (int)position.Y; i >= 0; i--)
                    {
                        PositionList.Add(
                            new Tile(
                                new Vector2(position.X, i),
                                    Board.TileWidth,
                                    Board.TileHeight, true));
                    }
                    break;
                case Orientation.Down:
                    for (int i = (int)position.Y; i < Board.Height + length; i++)
                    {
                        PositionList.Add(
                            new Tile(
                                new Vector2(position.X, i),
                                    Board.TileWidth,
                                    Board.TileHeight, true));
                    }
                    break;
                case Orientation.Left:
                    for (int i = (int)position.X; i >= 0; i--)
                    {
                        PositionList.Add(
                            new Tile(
                                new Vector2(i, position.Y),
                                    Board.TileWidth,
                                    Board.TileHeight, true));
                    }
                    break;
                case Orientation.Right:
                    for (int i = (int)position.X; i < Board.Width + length; i++)
                    {
                        PositionList.Add(
                            new Tile(
                                new Vector2(i, position.Y),
                                    Board.TileWidth,
                                    Board.TileHeight, true));
                    }
                    break;
            }
        }
    }
}
