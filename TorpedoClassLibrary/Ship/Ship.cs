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
        public int Length { get; private set; }
        public int Health { get; private set; }
        public IList<ITile> PositionList { get; private set; }
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
                    for (int i = (int)position.Y; i > ((int)position.Y - length); i--)
                    {
                        PositionList.Add(Board.Positions[(int)position.X, i]);
                    }
                    break;
                case Orientation.Down:
                    for (int i = (int)position.Y; i < ((int)position.Y + length); i++)
                    {
                        PositionList.Add(Board.Positions[(int)position.X, i]);
                    }
                    break;
                case Orientation.Left:
                    for (int i = (int)position.X; i > ((int)position.X - length); i--)
                    {
                        PositionList.Add(Board.Positions[i, (int)position.Y]);
                    }
                    break;
                case Orientation.Right:
                    for (int i = (int)position.X; i < ((int)position.X + length); i++)
                    {
                        PositionList.Add(Board.Positions[i, (int)position.Y]);
                    }
                    break;
            }
        }
    }
}
