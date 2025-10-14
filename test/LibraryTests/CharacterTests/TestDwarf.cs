using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace TestLibrary;
public class TestDwarf
{
    private Dwarf Dwarf1;
    private Dwarf Dwarf2;

    [SetUp]
    public void Setup()
    {
        Dwarf1 = new Dwarf("Anto The Tiniest Dwarf");
        Dwarf2 = new Dwarf("Mario Bergara");

    }
    
    [Test]
    public void TestReceiveAttack()
    {
        Dwarf1.ReceiveAttack(55);
        Assert.That(Dwarf1.Health, Is.EqualTo(63)); //toma 37 de daño porque el helmet reduce 18
    }
    
    [Test]
     public void TestCure()
     {
        Dwarf1.ReceiveAttack(55);
        Dwarf1.Cure();
        Assert.That(Dwarf1.Health, Is.EqualTo(100)); //Se cura por completo
    }
   
    [Test]
     public void TestAddItem()
     {
        Dwarf1.AddItem(new Armor());
        Dwarf1.ReceiveAttack(56);
        Assert.That(Dwarf1.Health, Is.EqualTo(87)); //La armadura bloquea 25 y el casco 18
    }
[Test]
     public void TestRemoveItem()
    {
        Armor Armor1 = new Armor();
        Dwarf1.AddItem(Armor1);
        Dwarf1.RemoveItem(Armor1);
        Dwarf1.ReceiveAttack(55);
        Assert.That(Dwarf1.Health, Is.EqualTo(63)); //Sólo lo cubre el casco
    }


}