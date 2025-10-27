namespace Ucu.Poo.RoleplayGame.Enemies;

public class Bomber:Enemy
{
    public string Name { get; set; }
    private List<IItem> items = new List<IItem>();
    public Bomber(string name)
    {
        this.Name= name;
        VP = 1;
    }
}