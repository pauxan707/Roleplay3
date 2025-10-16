using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace TestLibrary;
public class TestDwarf
{
    private Dwarf _dwarf1;
    private Dwarf _dwarf2;

    [SetUp]
    public void Setup()
    {
        _dwarf1 = new Dwarf("Anto The Tiniest Dwarf");
        _dwarf2 = new Dwarf("Mario Bergara");

    }
    
    [Test]
    public void TestReceiveAttack() //Recive daño
    {
        _dwarf1.ReceiveAttack(55);
        Assert.That(_dwarf1.Health, Is.EqualTo(63)); //toma 37 de daño porque el helmet reduce 18
    }
    
    [Test]
     public void TestCure() //Recive daño y luego se cura completamente
     {
        _dwarf1.ReceiveAttack(55);
        _dwarf1.Cure();
        Assert.That(_dwarf1.Health, Is.EqualTo(100)); //Se cura por completo
    }
   
    [Test]
     public void TestAddItem() //Agrega un item
     {
        _dwarf1.AddItem(new Armor());
        _dwarf1.ReceiveAttack(56);
        Assert.That(_dwarf1.Health, Is.EqualTo(87)); //La armadura bloquea 25 y el casco 18
    }
[Test]
     public void TestRemoveItem() //Agrega y quita un item
    {
        Armor armor1 = new Armor();
        _dwarf1.AddItem(armor1);
        _dwarf1.RemoveItem(armor1);
        _dwarf1.ReceiveAttack(55);
        Assert.That(_dwarf1.Health, Is.EqualTo(63)); //Sólo lo cubre el casco
    }
[Test]
public void TestHealthNotNegative() //Comprueba que la vida no sea negativa si el daño supera la vida
{
    _dwarf1.ReceiveAttack(5000000); 
    Assert.That(_dwarf1.Health, Is.EqualTo(0));
} 

}