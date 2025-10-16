using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace TestLibrary;
public class TestWizard
{
    private Wizard _wizard1;
    private Wizard _wizard2;

    [SetUp]
    public void Setup()
    {
        _wizard1 = new Wizard("Marco The Mega Knight");
        _wizard2 = new Wizard("Fede The Golden Knight");

    }
    
    [Test]
    public void TestReceiveAttack() //Recive daño
    {
        _wizard1.ReceiveAttack(120);
        Assert.That(_wizard1.Health, Is.EqualTo(80)); //toma 20 de daño porque el staff bloquea 100
    }
    
    [Test]
     public void TestCure() //Recive daño y luego se cura completamente
     {
        _wizard1.ReceiveAttack(150);
        _wizard1.Cure();
        Assert.That(_wizard1.Health, Is.EqualTo(100)); //Se cura por completo
    }

    [Test]
    public void TestAddItem() //Agrega un item
    {
        _wizard1.AddItem(new Armor());
        _wizard1.ReceiveAttack(150);
        Assert.That(_wizard1.Health, Is.EqualTo(75)); //La armor bloquea 25 y el staff 100
    }
    
    [Test]
    public void TestRemoveItem() //Agrega y quita un item
    {
        Armor Armor2 = new Armor();
        _wizard1.AddItem(Armor2);
        _wizard1.RemoveItem(Armor2);
        _wizard1.ReceiveAttack(101);
        Assert.That(_wizard1.Health, Is.EqualTo(99)); //Sólo cubre con el staff
    }
    
    [Test]
    public void TestAddItemII() //Agrega un libro con un hechizo y comprueba su defenza
    {
        SpellsBook book1 = new SpellsBook();
        SpellOne spell1 = new SpellOne();
        book1.AddSpell(spell1);
        _wizard1.AddItem(book1);
        _wizard1.ReceiveAttack(180);
        Assert.That(_wizard1.Health, Is.EqualTo(90)); //Cubre con el staff y el spell
    }

    [Test]
     public void TestRemoveItemII() //Agrega un libro con un hechizo y luego lo quita
    {
        SpellsBook book1 = new SpellsBook();
        SpellOne spell1 = new SpellOne();
        book1.AddSpell(spell1);
        _wizard1.AddItem(book1);
        _wizard1.RemoveItem(book1);
        _wizard1.ReceiveAttack(180);
        Assert.That(_wizard1.Health, Is.EqualTo(20)); //Sólo cubre el staff
    }
[Test]
public void TestHealthNotNegative() //Comprueba que la vida no sea negativa si el daño supera la vida
{
    _wizard1.ReceiveAttack(5000000); 
    Assert.That(_wizard1.Health, Is.EqualTo(0));
} 

}