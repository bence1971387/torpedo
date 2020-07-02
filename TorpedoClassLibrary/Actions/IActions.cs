namespace TorpedoClassLibrary
{
    public interface IActions
    {
        IPlayer Player { get; set; }
        bool AttackOnCoordinate(ITile position);
    }
}