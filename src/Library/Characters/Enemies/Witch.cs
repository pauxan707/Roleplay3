namespace Ucu.Poo.RoleplayGame.Enemies;

public class Witch : Enemy
{
    public Witch(string name)
    {
        this.Name= name;
        this.VP = 2;
        this.AddItem(new Staff());
    }
}