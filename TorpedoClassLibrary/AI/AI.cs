using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TorpedoClassLibrary
{
    public sealed class AI : IAI
    {
        private int _shipHit = 0;
        private int _distanceFromFirstHit = 0;
        private bool _isShipDestroyed = false;
        private IPlayerArea _playerArea;
        private IPlayerArea _enemyPlayerArea;
        private IList<Neighbour> _lastMoves;
        private Random _random;
        private IEnumerable<Neighbour> Neighbours(ITile tile)
        {
            int positionX = (int)tile.Position.X;
            int positionY = (int)tile.Position.Y;
            if (positionX + 1 < Board.Width) 
            {
                yield return new Neighbour(Board.Positions[positionX + 1, positionY], Ship.Orientation.Right);
            }
            if (positionX - 1 >= 0)
            {
                yield return new Neighbour(Board.Positions[positionX - 1, positionY], Ship.Orientation.Left);
            }
            if (positionY + 1 < Board.Width)
            {
                yield return new Neighbour(Board.Positions[positionX, positionY + 1], Ship.Orientation.Down);
            }
            if (positionY - 1 >= 0)
            {
                yield return new Neighbour(Board.Positions[positionX, positionY - 1], Ship.Orientation.Up);
            }
        }
        private void DestroyRestShip(Neighbour neighbour)
        {
            if (_distanceFromFirstHit > 4 && _distanceFromFirstHit > 0)
            {
                _distanceFromFirstHit--;
            }
            else
            {
                _distanceFromFirstHit++;
            }
            switch (neighbour.orientation)
            {
                case Ship.Orientation.Up:
                    if (((int)neighbour.tile.Position.Y - _distanceFromFirstHit) >= 0)
                    {
                        _playerArea.Player.Actions.AttackOnCoordinate(Board.Positions[(int)neighbour.tile.Position.X, (int)neighbour.tile.Position.Y - _distanceFromFirstHit]);
                    }
                    neighbour.orientation = Ship.Orientation.Down;
                    break;
                case Ship.Orientation.Down:
                    if (((int)neighbour.tile.Position.Y + _distanceFromFirstHit) < Board.Height)
                    {
                        _playerArea.Player.Actions.AttackOnCoordinate(Board.Positions[(int)neighbour.tile.Position.X, (int)neighbour.tile.Position.Y + _distanceFromFirstHit]);
                    }
                    neighbour.orientation = Ship.Orientation.Up;
                    break;
                case Ship.Orientation.Left:
                    if (((int)neighbour.tile.Position.X - _distanceFromFirstHit) >= 0) {
                        _playerArea.Player.Actions.AttackOnCoordinate(Board.Positions[(int)neighbour.tile.Position.X - _distanceFromFirstHit, (int)neighbour.tile.Position.Y]);
                    }
                    neighbour.orientation = Ship.Orientation.Right;
                    break;
                case Ship.Orientation.Right:
                    if(((int)neighbour.tile.Position.X + _distanceFromFirstHit) < Board.Width){
                        _playerArea.Player.Actions.AttackOnCoordinate(Board.Positions[(int)neighbour.tile.Position.X + _distanceFromFirstHit, (int)neighbour.tile.Position.Y]);
                    }
                    neighbour.orientation = Ship.Orientation.Left;
                    break;
            }
        }
        private void SubScribeShipEvents()
        {
            foreach (var playerArea in Board.PlayerAreaList)
            {
                if (playerArea.Player != _playerArea.Player)
                {
                    _enemyPlayerArea = playerArea;
                    foreach (var ship in playerArea.Player.ShipList)
                    {
                        ship.EventShipHit += ShipHit;
                        ship.EventShipDestroyed += ShipDestroyed;
                    }
                }
            }
        }
        private void ShipDestroyed(object sender, EventArgs e)
        {
            _lastMoves.Clear();
            _shipHit = 0;
            _distanceFromFirstHit = 0;
            _isShipDestroyed = true;
        }
        private void ShipHit(object sender, ITile tile)
        {
            _shipHit++;
            if (_shipHit >= 2)
            {
                Neighbour neighbourSend = new Neighbour(tile, _lastMoves.Last().orientation);
                DestroyRestShip(neighbourSend);
            }
            foreach (Neighbour neighbour in Neighbours(tile))
            {
                _lastMoves.Add(neighbour);
            }
        }
        public void Attack()
        {
            if (_lastMoves.Count == 0)
            {
                SubScribeShipEvents();
                int selectedTileIndex = _random.Next(0, _enemyPlayerArea.PositionList.Count - 1);
                //_playerArea.Player.Actions.AttackOnCoordinate(Board.Positions[0, 0]);
                _playerArea.Player.Actions.AttackOnCoordinate(_enemyPlayerArea.PositionList[selectedTileIndex]);
                //subscribe to hit and destroy events of other players
            }
            else
            {
                _playerArea.Player.Actions.AttackOnCoordinate(_lastMoves.Last().tile);
            }
        }
        public AI(IPlayer player)
        {
            _random = new Random();
            _lastMoves = new List<Neighbour>();
            foreach (var playerArea in Board.PlayerAreaList)
            {
                if (playerArea.Player == player)
                {
                    _playerArea = playerArea;
                }
            }
        }
        private class Neighbour
        {
            public ITile tile { get; private set; }
            public Ship.Orientation orientation { get; set; }

            public Neighbour(ITile tile, Ship.Orientation orientation)
            {
                this.tile = tile;
                this.orientation = orientation;
            }
        }
    }
}
