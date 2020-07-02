using System.Numerics;
using System.Windows.Shapes;

namespace TorpedoClassLibrary
{
    public interface ITile
    {
        Rectangle Display { get; set; }
        bool IsActive { get; set; }
        Vector2 Position { get; }
        double Width { get; }
        double Height { get; }
    }
}