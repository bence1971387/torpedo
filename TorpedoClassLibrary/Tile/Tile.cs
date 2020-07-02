using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TorpedoClassLibrary
{
    public sealed class Tile : ITile
    {
        public Rectangle Display { get; set; }
        public Vector2 Position { get; private set; }
        public bool IsActive { get; set; } = true;
        public double Width { get; private set; }
        public double Height { get; private set; }
        public Tile(Vector2 position, Rectangle display, bool isActive = true)
        {
            Display = display;
            Position = position;
            IsActive = isActive;
            Width = Board.TileWidth;
            Height = Board.TileHeight;
        }
    }
}
