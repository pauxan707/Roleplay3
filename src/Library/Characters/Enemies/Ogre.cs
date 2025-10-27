namespace Ucu.Poo.RoleplayGame.Enemies;

public class Ogre:Enemy
{
    public string Name { get; set; }
    
    private List<IItem> items = new List<IItem>();
    public Ogre(string name)
    {
        this.Name= name;
        VP = 1;
        items.Add(new Armor());
    }
}