using System.Linq; //usamos Linq para facilitar chequeos dentro de listas (Any())

namespace Library;

//se le pueden cargar listas de personajes al inicializarse, o no. Y luego se pueden agregar y quitar (se agrega al final, se quita el que se especifique) (podrían agregarse en una posición específica implementando un método distinto)
public class Encounter //se encarga de toda la lógica de combate, de esta manera cumpliendo con SRP. Cumple con Expert, ya que es la única clase con el conocimeinto de todos los combatientes.
{
    private List<Hero> _heroesList = new List<Hero>();
    private List<Enemy> _enemyList = new List<Enemy>();
    
    public Encounter(List<Hero> heroes, List<Enemy> enemies)
    {
        foreach (Hero hero in heroes) //eliminación de duplicados en listas iniciales
        {
            if (!_heroesList.Contains(hero))
            {
                _heroesList.Add(hero);
            }
        }
        
        foreach (Enemy enemy in enemies) 
        {
            if (!_heroesList.Contains(enemy))
            {
                _heroesList.Add(enemy);
            }
        }
    }

    public Encounter() //sobrecarga de constructor, si no se pasan parámetros, no hace nada, pero compila
    {
        ;
    }

    public void addHero(Hero hero)
    {
        if (!_heroesList.Contains(hero)) //validación para duplicados
        {
            _heroesList.Add(hero);
        }
        else
        {
            Console.WriteLine("" + hero + "ya se encuentra en el encuentro!");
        }
    }
     
    public void addEnemy(Enemy enemy)
    {
        if (!_enemyList.Contains(enemy)) //validación para duplicados
        {
            _enemyList.Add(enemy);
        }
        else
        {
            Console.WriteLine("" + enemy + "ya se encuentra en el encuentro!");
        }
    }    
    
    private void DoEncounter()
    {
        while (_heroesList.Any(hero => hero.Health > 0) && _enemyList.Any(enemy => enemy.Health > 0)) //solo continua la pelea si ambos bandos tienen combatientes vivos
        {
            //==============ataque enemigos================
            int heroIndex = 0;
        
            foreach (Enemy enemy in _enemyList)
            {
                if (enemy.Health <= 0)
                {
                    continue; //salta enemigos muertos
                }

                List<Hero> aliveHeroes = _heroesList.Where(hero => hero.Health > 0).ToList(); //antes de cada ataque, se calculan los heroes vivos
            
                //si ya no quedan héroes vivos, termina el while
                if (aliveHeroes.Count == 0)
                {
                    break;
                }

                //si heroIndex se pasa, regresa a 0, por ejemplo en 2 heroes 3 enemigos, el enemigo 3 ataca al heroe 1
                if (heroIndex >= aliveHeroes.Count)
                {
                    heroIndex = 0;
                }
            
                aliveHeroes[heroIndex].RecieveAttack(enemy.AttackValue);
                
                heroIndex++;
            }
        
            
            if (!_heroesList.Any(hero => hero.Health > 0)) //verifica si quedan heroes vivos para atacar
            {
                break;
            }
        
            //=============ataque heroes===============
            foreach (Hero hero in _heroesList)
            {
                if (hero.Health <= 0) //si el heroe está muerto, lo skippea
                {
                    continue;
                }
            
                foreach (Enemy enemy in _enemyList)
                {
                    if (enemy.Health <= 0) continue;
                
                    enemy.RecieveAttack(hero.AttackValue);

                    if (enemy.Health <= 0) //si mató al enemigo, absorbe sus VP
                    {
                        hero.VP += enemy.VP;

                        if (hero.VP >= 5) //si llega a 5 o más VP, pierde 5 y se cura!
                        {
                            hero.VP -= 5;
                            hero.Cure();
                        }
                    }
                }
            }
        }
    
        //mensaje de resultado del encuentro
        if (!_heroesList.Any(hero => hero.Health > 0))
        {
            Console.WriteLine("¡Los héroes han sido derrotados!");
        }
        else
        {
            Console.WriteLine("¡Los enemigos han sido derrotados!");
        }
    }
}