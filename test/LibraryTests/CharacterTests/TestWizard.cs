using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace TestLibrary;
public class TestWizard
{
    private Wizard Wizard1;
    private Wizard Wizard2;

    [SetUp]
    public void Setup()
    {
        Wizard1 = new Wizard("Marco The Mega Knight");
        Wizard2 = new Wizard("Fede The Golden Knight");

    }
    
    [Test]
    public void TestReceiveAttack()
    {
        Wizard1.ReceiveAttack(55);
        Assert.That(Wizard1.Health, Is.EqualTo(100)); //toma 0 de daño porque el staff bloquea 100
    }
    
    [Test]
     public void TestCure()
     {
        Wizard1.ReceiveAttack(55);
        Wizard1.Cure();
        Assert.That(Wizard1.Health, Is.EqualTo(100)); //Se cura por completo
    }

    [Test]
    public void TestAddItem()
    {
        Wizard1.AddItem(new Armor());
        Wizard1.ReceiveAttack(150);
        Assert.That(Wizard1.Health, Is.EqualTo(75)); //La armor bloquea 25 y el staff 100
    }
    
    [Test]
    public void TestRemoveItem()
    {
        Armor Armor2 = new Armor();
        Wizard1.AddItem(Armor2);
        Wizard1.RemoveItem(Armor2);
        Wizard1.ReceiveAttack(101);
        Assert.That(Wizard1.Health, Is.EqualTo(99)); //Sólo cubre con el staff
    }
    
    [Test]
    public void TestAddItemII()
    {
        SpellsBook Book1 = new SpellsBook();
        SpellOne spell1 = new SpellOne();
        Book1.AddSpell(spell1);
        Wizard1.AddItem(Book1);
        Wizard1.ReceiveAttack(180);
        Assert.That(Wizard1.Health, Is.EqualTo(90)); //Cubre con el staff y el spell
    }

    [Test]
     public void TestRemoveItemII()
    {
        SpellsBook Book1 = new SpellsBook();
        SpellOne spell1 = new SpellOne();
        Book1.AddSpell(spell1);
        Wizard1.AddItem(Book1);
        Wizard1.RemoveItem(Book1);
        Wizard1.ReceiveAttack(180);
        Assert.That(Wizard1.Health, Is.EqualTo(20)); //Sólo cubre el staff
    }


}