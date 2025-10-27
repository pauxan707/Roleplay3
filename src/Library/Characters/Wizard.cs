using System.Collections.Generic;
namespace Ucu.Poo.RoleplayGame;

public class Wizard: Hero, IMagicCharacter
{
    private int health = 100;

    public List<IItem> Items { get; } = new List<IItem>();

    public List<IMagicalItem> MagicalItems { get; } = new List<IMagicalItem>();

    public Wizard(string name)
    {
        this.Name = name;

        this.AddItem(new Staff());
    }

    public string Name { get; set; }

    public int AttackValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.Items)
            {
                if (item is IAttackItem)
                {
                    value += (item as IAttackItem).AttackValue;
                }
            }
            foreach (IMagicalItem item in this.MagicalItems)
            {
                if (item is IMagicalAttackItem)
                {
                    value += (item as IMagicalAttackItem).AttackValue;
                }
            }
            return value;
        }
    }

    public int DefenseValue
    {
        get
        {
            int value = 0;
            foreach (IItem item in this.Items)
            {
                if (item is IDefenseItem)
                {
                    value += (item as IDefenseItem).DefenseValue;
                }
            }
            foreach (IMagicalItem item in this.MagicalItems)
            {
                if (item is IMagicalDefenseItem)
                {
                    value += (item as IMagicalDefenseItem).DefenseValue;
                }
            }
            return value;
        }
    }

    public int Health
    {
        get
        {
            return this.health;
        }
        private set
        {
            this.health = value < 0 ? 0 : value;
        }
    }

    public void ReceiveAttack(int power)
    {
        if (this.DefenseValue < power)
        {
            this.Health -= power - this.DefenseValue;
        }
    }

    public void Cure()
    {
        this.Health = 100;
    }

    public void AddItem(IItem item)
    {
        this.Items.Add(item);
    }

    public void RemoveItem(IItem item)
    {
        this.Items.Remove(item);
    }

    public void AddItem(IMagicalItem item)
    {
        this.MagicalItems.Add(item);
    }

    public void RemoveItem(IMagicalItem item)
    {
        this.MagicalItems.Remove(item);
    }

}
