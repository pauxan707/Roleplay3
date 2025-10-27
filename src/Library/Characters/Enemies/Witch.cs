namespace Ucu.Poo.RoleplayGame.Enemies;

public class Witch : Enemy
{
    public string Name { get; set; }
    private List<IItem> items = new List<IItem>(); 
    
    public Witch(string name)
    {
        this.Name= name;
        VP = 2;
        items.Add(new Staff());
    }
}