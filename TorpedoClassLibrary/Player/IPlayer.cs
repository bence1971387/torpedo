using System;
using System.Collections.Generic;
using System.Numerics;

namespace TorpedoClassLibrary
{
    public interface IPlayer
    {
        event EventHandler<int> ScoreChanged;
        IActions Actions { get; set; }
        Player.Type PlayerType { get; }
        string Name { get; }
        int Score { get; }
        IList<IShip> ShipList { get; }
        IList<IShip> ShipDestroyedList { get; }
        void AddToScore(int score);
        void AddShip(IShip ship);
    }
}