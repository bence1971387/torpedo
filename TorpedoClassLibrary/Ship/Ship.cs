using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    public sealed class Ship : IShip
    {
        public enum Orientation { Up, Down, Left, Right };

        public event EventHandler<int> EventShipHit;
        public event EventHandler EventShipDestroyed;

        public int Length { get; set; }
        public int Health { get; set; }
        public IList<ITile> PositionList { get; set; }
        public void Hit(int damage, ITile position)
        {
            EventShipHit(this, damage);
            Health -= damage;
            PositionList.Remove(position);
            if (Health <= 0)
            {
                EventShipDestroyed(this, EventArgs.Empty);
            }
        }

        internal Ship(int length, Vector2 position, Orientation orientation)
        {
            Length = length;
            Health = length;
            PositionList = new List<ITile>();
            switch (orientation)
            {
                case Orientation.Up:
                    for (int i = (int)position.Y; i >= length; i--)
                    {
                        PositionList.Add(
                            new Tile(
                                new Vector2(position.X, i),
                                    true));
                    }
                    break;
                case Orientation.Down:
                    for (int i = (int)position.Y; i < Board.Height + length; i++)
                    {
                        PositionList.Add(
                            new Tile(
                                new Vector2(position.X, i),
                                    true));
                    }
                    break;
                case Orientation.Left:
                    for (int i = (int)position.X; i >= 0; i--)
                    {
                        PositionList.Add(
                            new Tile(
                                new Vector2(i, position.Y),
                                    true));
                    }
                    break;
                case Orientation.Right:
                    for (int i = (int)position.X; i < Board.Width + length; i++)
                    {
                        PositionList.Add(
                            new Tile(
                                new Vector2(i, position.Y),
                                    true));
                    }
                    break;
            }
        }
    }
}
