using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    class Tile
    {
        int X { get; set; }
        int Y { get; set; }
        bool IsActive { get; set; }

        public Tile(int x, int y, bool isActive)
        {
            X = x;
            Y = y;
            IsActive = isActive;
        }
    }
}
