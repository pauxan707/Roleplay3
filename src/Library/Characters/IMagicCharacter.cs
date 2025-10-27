namespace Ucu.Poo.RoleplayGame;

public interface IMagicCharacter
{
    public List<IMagicalItem> MagicalItems { get; set; }

    public void AddMagicalItem(IMagicalItem item);
}