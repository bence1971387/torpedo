using System.Numerics;
using System.Windows.Shapes;

namespace TorpedoClassLibrary
{
    public interface ITile
    {
        Rectangle Display { get; set; }
        double Height { get; }
        bool IsActive { get; set; }
        Vector2 Position { get; }
        double Width { get; }

        void Hide();
        void SetDisplay(Tile.DisplayType type);
    }
}