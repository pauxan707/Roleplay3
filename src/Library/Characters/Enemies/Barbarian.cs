namespace Ucu.Poo.RoleplayGame.Enemies;

public class Barbarian:Enemy
{
    public string Name { get; set; }
    
    public Barbarian(string name)
    {
        this.Name= name;
        VP = 2;
    }
}