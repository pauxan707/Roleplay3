using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace TestLibrary;

public class TestSpellsBook
{
    private SpellOne _spellOne1;
    private SpellsBook _spellsBook1;

    [SetUp]
    public void Setup()
    {
        _spellOne1 = new SpellOne();
        _spellsBook1 = new SpellsBook();

    }

[Test]
    public void TestAddSpell() //Añade un Spell al SpellsBook
    {
        _spellsBook1.AddSpell(_spellOne1);
        Assert.That(_spellsBook1.DefenseValue, Is.EqualTo(70)); //El SpellOne tiene 70 de valor de defenza + 0 de lo que tiene inicialmente el libro = 70
    }

[Test]
    public void TestRemoveSpell() //Añade y quita un Spell del SpellsBook
    {
        _spellsBook1.AddSpell(_spellOne1);
        _spellsBook1.RemoveSpell(_spellOne1);
        Assert.That(_spellsBook1.AttackValue, Is.EqualTo(0)); //Ya no tiene AttackValue tras quitarle el hechizo
    }


}
    