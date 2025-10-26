namespace Ucu.Poo.RoleplayGame.Enemies;

public class Bomber:Enemy
{
    public string Name { get; set; }
    public Bomber(string name)
    {
        this.Name= name;
        VP = 1;
    }
}