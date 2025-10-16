using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace TestLibrary;
public class TestOgre
{
    private Ogre _ogre1;
    private Ogre _ogre2;

    [SetUp]
    public void Setup()
    {
        _ogre1 = new Ogre("Fede The Sanctimonious Ogre");
        _ogre2 = new Ogre("Marco The Deranged Ogre");

    }
    
    [Test]
    public void TestReceiveAttack() //Recive daño
    {
        _ogre1.ReceiveAttack(55);
        Assert.That(_ogre1.Health, Is.EqualTo(70)); //toma 30 de daño porque el armor reduce 25
    }
    
    [Test]
     public void TestCure() //Recive daño y luego se cura completamente
     {
        _ogre1.ReceiveAttack(55);
        _ogre1.Cure();
        Assert.That(_ogre1.Health, Is.EqualTo(100)); //Se cura por completo
    }
   
    [Test]
     public void TestAddItem() //Agrega un item
     {
        _ogre1.AddItem(new Armor());
        _ogre1.ReceiveAttack(55);
        Assert.That(_ogre1.Health, Is.EqualTo(95)); //Como tiene 2 armaduras, bloquea 50
    }
[Test]
     public void TestRemoveItem() //Agrega y quita un item
    {
        Armor armor1 = new Armor();
        _ogre1.AddItem(armor1);
        _ogre1.RemoveItem(armor1);
        _ogre1.ReceiveAttack(55);
        Assert.That(_ogre1.Health, Is.EqualTo(70)); //Sólo lo cubre la armadura
    }
[Test]
     public void TestVP() 
    {
        Assert.That(_ogre1.VP(), Is.EqualTo(4)); //Comprueba que los VP sean los correctos
    }
[Test]
public void TestHealthNotNegative() //Comprueba que la vida no sea negativa si el daño supera la vida
{
    _ogre1.ReceiveAttack(5000000); 
    Assert.That(_ogre1.Health, Is.EqualTo(0));
} 
}
