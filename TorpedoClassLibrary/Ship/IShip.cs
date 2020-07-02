using System;
using System.Collections.Generic;

namespace TorpedoClassLibrary
{
    public interface IShip
    {
        event EventHandler<int> EventShipHit;
        event EventHandler EventShipDestroyed;
        int Health { get; }
        int Length { get; }
        IList<ITile> PositionList { get; }
        IList<ITile> DamagedPositionList { get; }
        void Hit(int damage, ITile tile);
    }
}