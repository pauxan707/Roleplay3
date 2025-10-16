using NUnit.Framework;
using Ucu.Poo.RoleplayGame;

namespace TestLibrary;

public class TestEncounter
{
    private Archer _archer1;
    private Wizard _wizard1;
    private Ogre _ogre1;
    private Barbarian _barbarian1;
    private Encounter _encounter1;

    [SetUp]
    public void Setup()
    {
        _archer1 = new Archer("Fede The Magic Archer");
        _wizard1 = new Wizard("Marco The Fire Wizard");
        _ogre1 = new Ogre("Anto The Sanctimonious Ogre");
        _barbarian1 = new Barbarian("Ianai The Harmful Barbarian");
        _encounter1 = new Encounter();

    }

    [Test]
    public void TestAddHero() //Añade un Hero al Encounter
    {
        _encounter1.AddHero(_archer1);
        Assert.That(_encounter1._heroesList, Has.Member(_archer1)); //Sólo está el archer
    }

    [Test]
    public void TestAddEnemy() //Añade un Enemy al Encounter
    {
        _encounter1.AddEnemy(_ogre1);
        Assert.That(_encounter1._enemyList, Has.Member(_ogre1)); //Sólo está el ogre
    }

    [Test]
    public void TestDeleteHero() //Añade y elimina un Hero al Encounter
    {
        _encounter1.AddHero(_archer1);
        _encounter1.DeleteHero(_archer1);
        Assert.That(_encounter1._heroesList, Is.Empty); //No hay ningun Hero
    }

    [Test]
    public void TestDeleteEnemy() //Añade y elimina un Enemy al Encounter
    {
        _encounter1.AddEnemy(_ogre1);
        _encounter1.DeleteEnemy(_ogre1);
        Assert.That(_encounter1._enemyList, Is.Empty); //No hay ningun Enemy
    }

    [Test]
    public void TestDoEncounterI()
    {
        _encounter1.AddEnemy(_ogre1);
        _encounter1.AddEnemy(_barbarian1);
        _encounter1.AddHero(_archer1);
        _encounter1.AddHero(_wizard1);
        _encounter1.DoEncounter();
        Assert.Multiple(() =>
        {
            Assert.That(_ogre1.Health, Is.EqualTo(35)); //Lo ataca el mago y el arquero
            Assert.That(_barbarian1.Health, Is.EqualTo(21)); //Lo ataca el mago y el arquero
            Assert.That(_archer1.Health, Is.EqualTo(78)); //Lo ataca el ogro
            Assert.That(_wizard1.Health, Is.EqualTo(100)); //Lo ataca el barbaro y bloquea todo
        }
        );
    }

    [Test]
    public void TestDoEncounterII() //Hace que un heroe mate a un enemigo, para probar que de los VP
    {
        _encounter1.AddEnemy(_ogre1);
        _encounter1.AddHero(_archer1);
        _ogre1.ReceiveAttack(124); //Hacemos que el ogro quede a un golpe
        _encounter1.DoEncounter(); //El ogro es derrotado
        Assert.That(_archer1.CollectedVp, Is.EqualTo(4)); //Los VP deberian ser 4
    }

  [Test]
    public void TestDoEncounterIII() //Se le da VP a un heroe a ver si se cura
    {
        _encounter1.AddEnemy(_ogre1);
        _encounter1.AddHero(_archer1);
        _archer1.ReceiveAttack(55);
        _archer1.CollectedVp = 5;
        _encounter1.DoEncounter(); //El arquero se cura por completo con 5 VP
        Assert.That(_archer1.Health, Is.EqualTo(100));
    }

}


