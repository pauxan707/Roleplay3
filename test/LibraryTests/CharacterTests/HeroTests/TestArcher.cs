using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace TestLibrary;
public class TestArcher
{
    private Archer _archer1;
    private Archer _archer2;

    [SetUp]
    public void Setup()
    {
        _archer1 = new Archer("Fede The Magic Archer");
        _archer2 = new Archer("Marco The Mystical Archer");

    }
    
    [Test]
    public void TestReceiveAttack() //Recive daño
    {
        _archer1.ReceiveAttack(55);
        Assert.That(_archer1.Health, Is.EqualTo(63)); //toma 37 de daño porque el helmet reduce 18
    }
    
    [Test]
     public void TestCure() //Recive daño y luego se cura completamente
     {
        _archer1.ReceiveAttack(55);
        _archer1.Cure();
        Assert.That(_archer1.Health, Is.EqualTo(100)); //Se cura por completo
    }
   
    [Test]
     public void TestAddItem() //Agrega un item
     {
        _archer1.AddItem(new Armor());
        _archer1.ReceiveAttack(55);
        Assert.That(_archer1.Health, Is.EqualTo(88)); //La armadura bloquea 25 y el casco 18
    }
[Test]
     public void TestRemoveItem() //Agrega y quita un item
    {
        Armor armor1 = new Armor();
        _archer1.AddItem(armor1);
        _archer1.RemoveItem(armor1);
        _archer1.ReceiveAttack(55);
        Assert.That(_archer1.Health, Is.EqualTo(63)); //Sólo lo cubre el casco
    }
[Test]
public void TestHealthNotNegative() //Comprueba que la vida no sea negativa si el daño supera la vida
{
    _archer1.ReceiveAttack(5000000); 
    Assert.That(_archer1.Health, Is.EqualTo(0));
} 

}