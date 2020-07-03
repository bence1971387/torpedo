using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.Windows.Media;
using System.Windows.Shapes;

namespace TorpedoClassLibrary
{
    public sealed class Tile : ITile
    {
        private bool _isHidden = false;
        private Rectangle _savedState;
        private readonly Rectangle _displayTile;
        private readonly Rectangle _displayDamage;
        private readonly Rectangle _displayShip;
        private readonly Rectangle _displayAttack;
        public enum DisplayType { Tile, Attack, Damage, Ship }
        public Rectangle Display { get; set; }
        public Vector2 Position { get; private set; }
        public bool IsActive { get; set; } = true;
        public double Width { get; private set; }
        public double Height { get; private set; }
        public void Hide()
        {
            _isHidden = !_isHidden;
            if (_isHidden)
            {
                _savedState = Display;
                Display = _displayTile;
            }
            else
            {
                Display = _savedState;
            }
        }
        public void SetDisplay(DisplayType type)
        {
            switch (type)
            {
                case DisplayType.Tile:
                    Display = _displayTile;
                    break;
                case DisplayType.Attack:
                    Display = _displayAttack;
                    break;
                case DisplayType.Damage:
                    Display = _displayDamage;
                    break;
                case DisplayType.Ship:
                    Display = _displayShip;
                    break;
                default:
                    break;
            }
        }
        public Tile(Vector2 position, bool isActive = true)
        {
            Rectangle displayDamage = new Rectangle
            {
                Stroke = Brushes.Black,
                Fill = Brushes.Red,
                StrokeThickness = 2,
                Width = Board.TileWidth,
                Height = Board.TileHeight
            };
            _displayDamage = displayDamage;
            Rectangle displayShip = new Rectangle
            {
                Stroke = Brushes.Black,
                Fill = Brushes.Green,
                StrokeThickness = 2,
                Width = Board.TileWidth,
                Height = Board.TileHeight
            };
            _displayShip = displayShip;
            Rectangle displayTile = new Rectangle
            {
                Stroke = Brushes.Black,
                Fill = Brushes.White,
                StrokeThickness = 2,
                Width = Board.TileWidth,
                Height = Board.TileHeight
            };
            _displayTile = displayTile;
            Rectangle displayAttack = new Rectangle
            {
                Stroke = Brushes.Black,
                Fill = Brushes.LightBlue,
                StrokeThickness = 2,
                Width = Board.TileWidth,
                Height = Board.TileHeight
            };
            _displayAttack = displayAttack;
            Display = _displayTile;
            Position = position;
            IsActive = isActive;
            Width = Board.TileWidth;
            Height = Board.TileHeight;
        }
    }
}
