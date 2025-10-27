namespace Ucu.Poo.RoleplayGame.Enemies;

public class Barbarian:Enemy
{
    
    public Barbarian(string name)
    {
        this.Name= name;
        this.VP = 2;
        this.AddItem(new Helmet());
    }
}