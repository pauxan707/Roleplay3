using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Dwarf: Hero
{
    public Dwarf(string name)
    {
        this.Name = name;
        this.AddItem(new Bow());
        this.AddItem(new Helmet());
    }
}