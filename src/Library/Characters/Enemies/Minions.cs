namespace Ucu.Poo.RoleplayGame.Enemies;

public class Minions:Enemy
{
    public string Name { get; set; }
    public Minions(string name)
    {
        this.Name= name;
        VP = 2;
    }
}