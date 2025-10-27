namespace Ucu.Poo.RoleplayGame.Enemies;

public class Ogre:Enemy
{
    public Ogre(string name)
    {
        this.Name= name;
        this.VP = 1;
        this.AddItem(new Armor());
    }
}