using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Knight: Hero
{
    public Knight(string name)
    {
        this.Name = name;
        this.AddItem(new Bow());
        this.AddItem(new Helmet());
    }
}