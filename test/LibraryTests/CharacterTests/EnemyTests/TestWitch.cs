using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
using Ucu.Poo.RoleplayGame.Enemies;

namespace TestLibrary;
public class TestWitch
{
    private Witch _witch1;
    private Witch _witch2;

    [SetUp]
    public void Setup()
    {
        _witch1 = new Witch("Fede The Sanctimonious Witch");
        _witch2 = new Witch("Anto The malevolent Witch");

    }
    
    [Test]
    public void TestReceiveAttack() //Recive daño
    {
        _witch1.ReceiveAttack(150);
        Assert.That(_witch1.Health, Is.EqualTo(0)); 
    }
    
    [Test]
     public void TestCure() //Recive daño y luego se cura completamente
     {
        _witch1.ReceiveAttack(150);
        _witch1.Cure();
        Assert.That(_witch1.Health, Is.EqualTo(100)); //Se cura por completo
    }
   
    [Test]
     public void TestAddItem() //Agrega un item
     {
        _witch1.AddItem(new Armor());
        _witch1.ReceiveAttack(150);
        Assert.That(_witch1.Health, Is.EqualTo(0)); 
    }
[Test]
     public void TestRemoveItem() //Agrega y quita un item
    {
        Armor armor1 = new Armor();
        _witch1.AddItem(armor1);
        _witch1.RemoveItem(armor1);
        _witch1.ReceiveAttack(150);
        Assert.That(_witch1.Health, Is.EqualTo(0)); //Sólo lo cubre el staff
    }
[Test]
     public void TestVP() 
    {
        Assert.That(_witch1.VP, Is.EqualTo(2)); //Comprueba que los VP sean los correctos
    }
[Test]
public void TestHealthNotNegative() //Comprueba que la vida no sea negativa si el daño supera la vida
{
    _witch1.ReceiveAttack(5000000); 
    Assert.That(_witch1.Health, Is.EqualTo(0));
} 
}
