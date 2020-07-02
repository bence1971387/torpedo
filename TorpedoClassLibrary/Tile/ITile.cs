using System.Numerics;

namespace TorpedoClassLibrary
{
    public interface ITile
    {
        bool IsActive { get; set; }
        Vector2 Position { get; }
        double Width { get; }
        double Height { get; }
    }
}