﻿using System;
using System.Collections.Generic;
using System.Numerics;

namespace TorpedoClassLibrary
{
    public interface IPlayer
    {
        IActions Actions { get; set; }
        Player.Type PlayerType { get; }
        string Name { get; }
        int Score { get; }
        IList<IShip> ShipList { get; }
        void AddToScore(int score);

        void AddShip(IShip ship);
    }
}