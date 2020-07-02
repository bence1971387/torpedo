using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    internal class PlayerArea : IPlayerArea
    {
        public IPlayer Player { get; private set; }
        public IList<ITile> PositionList { get; private set; }
        public PlayerArea(IPlayer player, IList<ITile> positionList)
        {
            Player = player;
            PositionList = positionList;
        }
    }
}
