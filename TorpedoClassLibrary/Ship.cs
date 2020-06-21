using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    class Ship
    {
        int GetLength { get; set; }
        int GetHealth { get; set; }
        List<Tile> GetPositionList { get; set; }
    }
}
