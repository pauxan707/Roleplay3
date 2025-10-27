namespace Ucu.Poo.RoleplayGame.Enemies;

public class Minions:Enemy
{
    public string Name { get; set; }
    private List<IItem> items = new List<IItem>();
    
    public Minions(string name)
    {
        this.Name= name;
        VP = 2;
        items.Add(new Shield()); 
    }
}