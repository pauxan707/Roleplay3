namespace Ucu.Poo.RoleplayGame.Enemies;

public class Minions:Enemy
{

    public Minions(string name)
    {
        this.Name= name;
        this.VP = 2;
        AddItem(new Shield()); 
    }
}