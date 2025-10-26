namespace Ucu.Poo.RoleplayGame.Enemies;

public class Ogre:Enemy
{
    public string Name { get; set; }
    public Ogre(string name)
    {
        this.Name= name;
        VP = 1;
    }
}