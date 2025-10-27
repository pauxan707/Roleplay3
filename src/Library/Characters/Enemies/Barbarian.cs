namespace Ucu.Poo.RoleplayGame.Enemies;

public class Barbarian:Enemy
{
    public string Name { get; set; }
    private List<IItem> items = new List<IItem>();
    
    public Barbarian(string name)
    {
        this.Name= name;
        VP = 2;
        this.AddItem(new Helmet());
    }
}