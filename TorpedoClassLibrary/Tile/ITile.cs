using System.Numerics;

namespace TorpedoClassLibrary
{
    public interface ITile
    {
        double Height { get; }
        bool IsActive { get; set; }
        Vector2 Position { get; }
        double Width { get; }
    }
}