namespace Ucu.Poo.RoleplayGame.Enemies;

public class Witch:Enemy
{
    public string Name { get; set; }
    public Witch(string name)
    {
        this.Name= name;
        VP = 2;
    }
}