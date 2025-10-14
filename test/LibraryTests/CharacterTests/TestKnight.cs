using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace TestLibrary;
public class TestKnight
{
    private Knight Knight1;
    private Knight Knight2;

    [SetUp]
    public void Setup()
    {
        Knight1 = new Knight("Marco The Mega Knight");
        Knight2 = new Knight("Fede The Golden Knight");

    }
    
    [Test]
    public void TestReceiveAttack()
    {
        Knight1.ReceiveAttack(55);
        Assert.That(Knight1.Health, Is.EqualTo(84)); //toma 16 de daño porque la armadura reduce 25 y el escudo 14
    }
    
    [Test]
     public void TestCure()
     {
        Knight1.ReceiveAttack(55);
        Knight1.Cure();
        Assert.That(Knight1.Health, Is.EqualTo(100)); //Se cura por completo
    }
   
    [Test]
     public void TestAddItem()
     {
        Knight1.AddItem(new Armor());
        Knight1.ReceiveAttack(69);
        Assert.That(Knight1.Health, Is.EqualTo(95)); //Las armaduras bloquean 50 y el escudo 14
    }
[Test]
     public void TestRemoveItem()
    {
        Armor Armor2 = new Armor();
        Knight1.AddItem(Armor2);
        Knight1.RemoveItem(Armor2);
        Knight1.ReceiveAttack(55);
        Assert.That(Knight1.Health, Is.EqualTo(84)); //Sólo cubre con 1 armadura y el escudo
    }


}