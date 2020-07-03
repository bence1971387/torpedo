using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TorpedoClassLibrary
{
    public sealed class Ship : IShip
    {
        public enum Orientation { Up, Down, Left, Right };
        public event EventHandler<ITile> EventShipHit;
        public event EventHandler EventShipDestroyed;
        public int Length { get; private set; }
        public int Health { get; private set; }
        public IList<ITile> PositionList { get; private set; }
        public IList<ITile> DamagedPositionList { get; private set; }
        public bool Hit(int damage, ITile tile)
        {
            if (!DamagedPositionList.Contains(tile))
            {
                tile.SetDisplay(Tile.DisplayType.Damage);
                EventShipHit(this, tile);
                Health -= damage;
                //PositionList.Remove(tile);
                DamagedPositionList.Add(tile);
                if (Health <= 0)
                {
                    EventShipDestroyed(this, EventArgs.Empty);
                }
                return true;
            }            
            return false;
        }
        internal Ship(int length, ITile tile, Orientation orientation)
        {
            
            Length = length;
            Health = length;
            PositionList = new List<ITile>();
            DamagedPositionList = new List<ITile>();
            switch (orientation)
            {
                case Orientation.Up:
                    for (int i = (int)tile.Position.Y; i > ((int)tile.Position.Y - length); i--)
                    {

                        Board.Positions[(int)tile.Position.X, i].SetDisplay(Tile.DisplayType.Ship);
                        PositionList.Add(Board.Positions[(int)tile.Position.X, i]);
                    }
                    break;
                case Orientation.Down:
                    for (int i = (int)tile.Position.Y; i < ((int)tile.Position.Y + length); i++)
                    {
                        Board.Positions[(int)tile.Position.X, i].SetDisplay(Tile.DisplayType.Ship);
                        PositionList.Add(Board.Positions[(int)tile.Position.X, i]);
                    }
                    break;
                case Orientation.Left:
                    for (int i = (int)tile.Position.X; i > ((int)tile.Position.X - length); i--)
                    {
                        Board.Positions[i, (int)tile.Position.Y].SetDisplay(Tile.DisplayType.Ship);
                        PositionList.Add(Board.Positions[i, (int)tile.Position.Y]);
                    }
                    break;
                case Orientation.Right:
                    for (int i = (int)tile.Position.X; i < ((int)tile.Position.X + length); i++)
                    {
                        Board.Positions[i, (int)tile.Position.Y].SetDisplay(Tile.DisplayType.Ship);
                        PositionList.Add(Board.Positions[i, (int)tile.Position.Y]);
                    }
                    break;
            }
        }
    }
}
