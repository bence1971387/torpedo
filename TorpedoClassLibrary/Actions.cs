using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    public class Actions
    {
        delegate void CoordinateSelect(int x, int y);
        event CoordinateSelect EventCoordinateSelect;
    }
}
