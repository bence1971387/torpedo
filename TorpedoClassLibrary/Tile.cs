using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace TorpedoClassLibrary
{
    public class Tile
    {
        public Vector2 Position { get; private set; }
        public bool IsActive { get; set; }
        public double Width { get; private set; }
        public double Height { get; private set; }
        public Tile(Vector2 position, int width, int height, bool isActive)
        {
            IsActive = isActive;
            this.Position = position;
            Width = width;
            Height = height;
        }
    }
}
