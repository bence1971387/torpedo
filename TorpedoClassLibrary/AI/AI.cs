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
        private bool _isShipHit = false;
        private bool _isShipDestroyed = false;
        private IPlayerArea _playerArea;
        private IList<ITile> _lastMoves;
        private Random _random;
        private IEnumerable<Neighbour> Neighbours(ITile tile)
        {
            int positionX = (int)tile.Position.X;
            int positionY = (int)tile.Position.Y;
            yield return new Neighbour(Board.Positions[positionX + 1, positionY],Ship.Orientation.Right);
            yield return new Neighbour(Board.Positions[positionX - 1, positionY],Ship.Orientation.Left);
            yield return new Neighbour(Board.Positions[positionX, positionY + 1],Ship.Orientation.Down);
            yield return new Neighbour(Board.Positions[positionX, positionY - 1],Ship.Orientation.Up);
        }
        private void DestroyRestShip(ITile tile, Ship.Orientation orientation)
        {

        }
        private void SubScribeShipEvents()
        {
            foreach (var player in Board.PlayerList)
            {
                if (player != _playerArea.Player)
                {
                    foreach (var ship in player.ShipList)
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
            _isShipHit = false;
            _isShipDestroyed = true;
        }
        private void ShipHit(object sender, ITile tile)
        {
            _isShipHit = true;
        }
        public void Attack()
        {
            if (_lastMoves.Count == 0)
            {
                SubScribeShipEvents();
                int selectedTileIndex = _random.Next(0, _playerArea.PositionList.Count - 1);
                //_playerArea.Player.Actions.AttackOnCoordinate(Board.Positions[0, 0]);
                _playerArea.Player.Actions.AttackOnCoordinate(_playerArea.PositionList[selectedTileIndex]);
                //subscribe to hit and destroy events of other players
            }
        }
        public AI(IPlayer player)
        {
            _random = new Random();
            _lastMoves = new List<ITile>();
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
            ITile tile { get; set; }
            Ship.Orientation orientation { get; set; }

            public Neighbour(ITile tile, Ship.Orientation orientation)
            {
                this.tile = tile;
                this.orientation = orientation;
            }
        }
    }
}
