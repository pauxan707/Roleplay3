using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
using Ucu.Poo.RoleplayGame.Enemies;

namespace TestLibrary;
public class TestMinions
{
    private Minions _minions1;
    private Minions _minions2;

    [SetUp]
    public void Setup()
    {
        _minions1 = new Minions("Fede The Vexatious Minion");
        _minions2 = new Minions("Anto The Sardonic Minion");

    }
    
    [Test]
    public void TestReceiveAttack() //Recive daño
    {
        _minions1.ReceiveAttack(55);
        Assert.That(_minions1.Health, Is.EqualTo(59)); //toma 41 de daño porque el shield reduce 14
    }
    
    [Test]
     public void TestCure() //Recive daño y luego se cura completamente
     {
        _minions1.ReceiveAttack(55);
        _minions1.Cure();
        Assert.That(_minions1.Health, Is.EqualTo(100)); //Se cura por completo
    }
   
    [Test]
     public void TestAddItem() //Agrega un item
     {
        _minions1.AddItem(new Armor());
        _minions1.ReceiveAttack(100);
        Assert.That(_minions1.Health, Is.EqualTo(39)); //Como tiene 1 armor y 1 shield, bloquea 39
    }
[Test]
     public void TestRemoveItem() //Agrega y quita un item
    {
        Armor armor1 = new Armor();
        _minions1.AddItem(armor1);
        _minions1.RemoveItem(armor1);
        _minions1.ReceiveAttack(55);
        Assert.That(_minions1.Health, Is.EqualTo(59)); //Sólo lo cubre el shield
    }
[Test]
     public void TestVP() 
    {
        Assert.That(_minions1.VP, Is.EqualTo(2)); //Comprueba que los VP sean los correctos
    }
[Test]
public void TestHealthNotNegative() //Comprueba que la vida no sea negativa si el daño supera la vida
{
    _minions1.ReceiveAttack(5000000); 
    Assert.That(_minions1.Health, Is.EqualTo(0));
} 
}
