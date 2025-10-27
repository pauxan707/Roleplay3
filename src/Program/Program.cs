using System;
using System.Collections.Generic;
using Ucu.Poo.RoleplayGame;
using Ucu.Poo.RoleplayGame.Enemies;
using Library;

namespace program;
class Program
{
    static void Main(string[] args)
    {
        // Crear héroes con sus nombres y stats iniciales
        var archer = new Archer("juan"); 

        var heroes = new List<Hero> { archer };

        // Crear enemigos con sus nombres y stats iniciales
        var barbarian = new Barbarian("Barbarian");
        var ogre = new Ogre("Ogre");
        var witch = new Witch("Witch");

        var enemies = new List<Enemy> { barbarian, ogre, witch };

        // Inicializar el encuentro con listas de héroes y enemigos
        var encounter = new Encounter(heroes, enemies);

        // Ejecutar el encuentro y mostrar progreso
        Console.WriteLine("== Comienza el Encuentro ==");
        encounter.DoEncounter();
        Console.WriteLine("== Fin del Encuentro ==");

        // Imprimir el estado final de los héroes tras el combate
        Console.WriteLine("\nEstado final de los héroes:");
        foreach (var hero in heroes)
        {
            Console.WriteLine($"{hero.GetType().Name} - HP: {hero.Health}, VP: {hero.VP}");
        }

        // Imprimir el estado final de los enemigos tras el combate
        Console.WriteLine("\nEstado final de los enemigos:");
        foreach (var enemy in enemies)
        {
            Console.WriteLine($"{enemy.GetType().Name} - HP: {enemy.Health}, VP: {enemy.VP}");
        }
    }
}
