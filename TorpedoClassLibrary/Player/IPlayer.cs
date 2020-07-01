using System.Collections.Generic;
using System.Numerics;

namespace TorpedoClassLibrary
{
    public interface IPlayer
    {
        Player.IActions Actions { get; set; }
        string Name { get; }
        int Score { get; }
        IList<IShip> ShipList { get; }

        void AddShip(IShip ship);
    }
}