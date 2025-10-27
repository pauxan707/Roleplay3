namespace Ucu.Poo.RoleplayGame;

public interface IMagicCharacter
{
    public List<IItem> Items { get; }
    public List<IMagicalItem> MagicalItems { get; }
}