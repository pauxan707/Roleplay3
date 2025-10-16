using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace TestLibrary;
public class TestKnight
{
    private Knight _knight1;
    private Knight _knight2;

    [SetUp]
    public void Setup()
    {
        _knight1 = new Knight("Marco The Mega Knight");
        _knight2 = new Knight("Fede The Golden Knight");

    }
    
    [Test]
    public void TestReceiveAttack() //Recive daño
    {
         _knight1.ReceiveAttack(55);
        Assert.That( _knight1.Health, Is.EqualTo(84)); //toma 16 de daño porque la armadura reduce 25 y el escudo 14
    }
    
    [Test]
     public void TestCure() //Recive daño y luego se cura completamente
     {
        _knight1.ReceiveAttack(55);
        _knight1.Cure();
        Assert.That( _knight1.Health, Is.EqualTo(100)); //Se cura por completo
    }
   
    [Test]
     public void TestAddItem() //Agrega un item
     {
        _knight1.AddItem(new Armor());
        _knight1.ReceiveAttack(69);
        Assert.That(_knight1.Health, Is.EqualTo(95)); //Las armaduras bloquean 50 y el escudo 14
    }
[Test]
     public void TestRemoveItem() //Agrega y quita un item
    {
        Armor armor2 = new Armor();
        _knight1.AddItem(armor2);
        _knight1.RemoveItem(armor2);
        _knight1.ReceiveAttack(55);
        Assert.That(_knight1.Health, Is.EqualTo(84)); //Sólo cubre con 1 armadura y el escudo
    }
[Test]
public void TestHealthNotNegative() //Comprueba que la vida no sea negativa si el daño supera la vida
{
    _knight1.ReceiveAttack(5000000); 
    Assert.That(_knight1.Health, Is.EqualTo(0));
} 

}