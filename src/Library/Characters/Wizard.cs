using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Wizard : Hero, IMagicCharacter
{
    
    public List<IMagicalItem> MagicalItems { get; set; } = new List<IMagicalItem>();
    public Wizard(string name)
    {
        this.Name = name;
        this.AddMagicalItem(new SpellsBook());
        this.AddItem(new Staff());
    }


    public void AddMagicalItem(IMagicalItem item)
    {
        this.MagicalItems.Add(item);
    }
}