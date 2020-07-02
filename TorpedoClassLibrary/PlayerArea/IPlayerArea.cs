using System.Collections.Generic;

namespace TorpedoClassLibrary
{
    public interface IPlayerArea
    {
        IPlayer Player { get; }
        IList<ITile> PositionList { get; }
    }
}