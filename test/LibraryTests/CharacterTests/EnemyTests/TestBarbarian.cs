using NUnit.Framework;
using Ucu.Poo.RoleplayGame;
using Ucu.Poo.RoleplayGame.Enemies;

namespace TestLibrary;
public class TestBarbarian
{
    private Barbarian _barbarian1;
    private Barbarian _barbarian2;

    [SetUp]
    public void Setup()
    {
        _barbarian1 = new Barbarian("Fede The Pecalcitrant Barbarian");
        _barbarian2 = new Barbarian("Anto The Perfidious Barbarian");

    }
    
    [Test]
    public void TestReceiveAttack() //Recibe daño
    {
        _barbarian1.ReceiveAttack(55);
        Assert.That(_barbarian1.Health, Is.EqualTo(63)); //Ataque de 55, helmet bloquea 18, daño es de 37. Vida 100 - 37 = 63
    }
    
    [Test]
     public void TestCure() //Recive daño y luego se cura completamente
     {
        _barbarian1.ReceiveAttack(55);
        _barbarian1.Cure();
        Assert.That(_barbarian1.Health, Is.EqualTo(100)); //Se cura por completo
    }
   
    [Test]
     public void TestAddItem() //Agrega un item
     {
        _barbarian1.AddItem(new Armor());
        _barbarian1.ReceiveAttack(100);
        Assert.That(_barbarian1.Health, Is.EqualTo(43)); // helmet + armor bloquean 43, daño 57. Vida 100 - 57 = 43
    }
[Test]
     public void TestRemoveItem() //Agrega y quita un item
    {
        Armor armor1 = new Armor();
        _barbarian1.AddItem(armor1);
        _barbarian1.RemoveItem(armor1);
        _barbarian1.ReceiveAttack(55);
        Assert.That(_barbarian1.Health, Is.EqualTo(63)); //Sólo lo cubre el helmet
    }
[Test]
    public void TestVP()
    {
        Assert.That(_barbarian1.VP, Is.EqualTo(2)); //Comprueba que los VP sean los correctos
    }
[Test]
public void TestHealthNotNegative() //Comprueba que la vida no sea negativa si el daño supera la vida
{
    _barbarian1.ReceiveAttack(5000000); 
    Assert.That(_barbarian1.Health, Is.EqualTo(0));
} 


}
