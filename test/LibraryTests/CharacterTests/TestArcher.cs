using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace TestLibrary;
public class TestArcher
{
    private Archer Archer1;
    private Archer Archer2;

    [SetUp]
    public void Setup()
    {
        Archer1 = new Archer("Fede The Magic Archer");
        Archer2 = new Archer("Marco The Mystical Archer");

    }
    
    [Test]
    public void TestReceiveAttack()
    {
        Archer1.ReceiveAttack(55);
        Assert.That(Archer1.Health, Is.EqualTo(63)); //toma 37 de daño porque el helmet reduce 18
    }
    
    [Test]
     public void TestCure()
     {
        Archer1.ReceiveAttack(55);
        Archer1.Cure();
        Assert.That(Archer1.Health, Is.EqualTo(100)); //Se cura por completo
    }
   
    [Test]
     public void TestAddItem()
     {
        Archer1.AddItem(new Armor());
        Archer1.ReceiveAttack(55);
        Assert.That(Archer1.Health, Is.EqualTo(88)); //La armadura bloquea 25 y el casco 18
    }
[Test]
     public void TestRemoveItem()
    {
        Armor Armor1 = new Armor();
        Archer1.AddItem(Armor1);
        Archer1.RemoveItem(Armor1);
        Archer1.ReceiveAttack(55);
        Assert.That(Archer1.Health, Is.EqualTo(63)); //Sólo lo cubre el casco
    }


}