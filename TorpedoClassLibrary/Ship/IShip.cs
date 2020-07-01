using System;
using System.Collections.Generic;

namespace TorpedoClassLibrary
{
    public interface IShip
    {
        int Health { get; set; }
        int Length { get; set; }
        IList<ITile> PositionList { get; set; }

        event EventHandler EventShipDestroyed;
        event EventHandler<int> EventShipHit;

        void Hit(int damage, ITile position);
    }
}