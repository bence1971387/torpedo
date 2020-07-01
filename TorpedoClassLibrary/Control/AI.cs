﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    public class AI : IAI
    {
        public Tile Attack()
        {
            Tile tile = new Tile(new Vector2(1, 1), true);
            Board.PlayerList[0].Actions.AttackOnCoordinate(Board.Positions[1,1]);
            return tile;
        }
    }
}
