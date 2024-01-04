using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;


class SuperAutoSimulator
{

    static int turnCounter = 0;
    static int gameNumber = 1;
    static int playerWins = 0;
    static int enemyWins = 0;
    static int playerDraws = 0;
    static double elapsedSeconds;

    static void Main()
    {

        string logFilePath = $"GameLog.txt";

        long numberOfBattles = 500;
        var watch = new System.Diagnostics.Stopwatch();

        using (StreamWriter sw = new StreamWriter(logFilePath))
        {
            watch.Start();
            for (int i = 0; i < numberOfBattles; i++)
            {
                turnCounter = 0;
                List<Unit> playerUnits = LoadRandomUnits(3);
                List<Unit> enemyUnits = LoadRandomUnits(3);

                //Console.WriteLine("Player's units:");
                DisplayUnits(playerUnits, "Player");

                //Console.WriteLine("\nEnemy's units:");
                DisplayUnits(enemyUnits, "Enemy");

                // Simulate a battle
                Battle(playerUnits, enemyUnits, sw);
            }
            watch.Stop();
            elapsedSeconds = (double)watch.ElapsedTicks / Stopwatch.Frequency;

            sw.WriteLine($"Player Wins: {playerWins}\nEnemy Wins: {enemyWins}\nplayerDraws: {playerDraws}\n\nTime To Compute: {elapsedSeconds} seconds");

        }
    }

    static List<Unit> LoadRandomUnits(int count)
    {
        List<Unit> allUnits = LoadUnitsFromJson("Pets.json");
        Random random = new Random();
        return allUnits.OrderBy(x => random.Next()).Take(count).ToList();
    }
    static List<Unit> LoadUnitsFromJson(string jsonFilePath)
    {
        string json = File.ReadAllText(jsonFilePath);
        return JsonConvert.DeserializeObject<List<Unit>>(json);
    }
    static void DisplayUnits(List<Unit> unitList, string owner)
    {
        foreach (var unit in unitList)
        {
            //Console.WriteLine($"{owner}'s {unit.Name}, Health: {unit.Health}, Attack: {unit.Attack}");
        }
    }

    static void Battle(List<Unit> playerUnits, List<Unit> enemyUnits, StreamWriter sw)
    {

            sw.WriteLine("--- Battle Log ---");
            while (playerUnits.Any() && enemyUnits.Any())
            {
                turnCounter++;

                // Log turn counter
                sw.WriteLine($"\nTurn {turnCounter}:");

                // Get the first pet from both player and enemy units
                Unit playerUnit = playerUnits.First();
                Unit enemyUnit = enemyUnits.First();

                // Display unit status
                //Console.WriteLine($"\nPlayer's unit: {playerUnit.Name}, Health: {playerUnit.Health}, Attack: {playerUnit.Attack}, Position: {playerUnit.Position}");
                sw.WriteLine($"\nPlayer's unit: {playerUnit.Name}, Health: {playerUnit.Health}, Attack: {playerUnit.Attack}, Position: {playerUnit.Position}");

                //Console.WriteLine($"Enemy's unit: {enemyUnit.Name}, Health: {enemyUnit.Health}, Attack: {enemyUnit.Attack}, Position: {enemyUnit.Position}");
                sw.WriteLine($"Enemy's unit: {enemyUnit.Name}, Health: {enemyUnit.Health}, Attack: {enemyUnit.Attack}, Position: {enemyUnit.Position}");

                // Check if the pets will kill each other
                BattleUnits(playerUnit, enemyUnit, sw);

                // Check if player's unit is defeated
                if (playerUnit.Health <= 0)
                {
                   //Console.WriteLine("Player unit defeated!");
                    sw.WriteLine("Player unit defeated!");
                    playerUnits.Remove(playerUnit);
                    AdjustPositions(playerUnits);
                }

                // Check if enemy's unit is defeated
                if (enemyUnit.Health <= 0)
                {
                    //Console.WriteLine("Enemy unit defeated!");
                    sw.WriteLine("Enemy unit defeated!");
                    enemyUnits.Remove(enemyUnit);
                    AdjustPositions(enemyUnits);
                }

                // Log unit status after the battle
                //Console.WriteLine("\nPlayer's units:");
                DisplayUnits(playerUnits, "Player");
                sw.WriteLine("\nPlayer's units:");
                foreach (var unit in playerUnits)
                {
                    sw.WriteLine($"{unit.Name}, Health: {unit.Health}, Attack: {unit.Attack}");
                }

                //Console.WriteLine("\nEnemy's units:");
                DisplayUnits(enemyUnits, "Enemy");
                sw.WriteLine("\nEnemy's units:");
                foreach (var unit in enemyUnits)
                {
                    sw.WriteLine($"{unit.Name}, Health: {unit.Health}, Attack: {unit.Attack}");
                }

                //Console.WriteLine("\n--- Next Turn ---");
                sw.WriteLine("\n--- Next Turn ---");
            }

            // Display the winner
            if (!playerUnits.Any() && !enemyUnits.Any())
            {
            playerDraws++;
               // Console.WriteLine("\nDRAW!");
                sw.WriteLine("\nDRAW!");
            }
            else if (enemyUnits.Any())
            {
            enemyWins++;
                //Console.WriteLine("\nEnemy wins!");
                sw.WriteLine("\nEnemy wins!");
            }
            else if (playerUnits.Any())
            {
            playerWins++;
                //Console.WriteLine("\nPlayer wins!");
                sw.WriteLine("\nPlayer wins!");
            }
        //Console.WriteLine($"\nGamecounter: {gameNumber}\n");
        sw.WriteLine($"\nGamecounter: {gameNumber}\n");
        gameNumber++;

    }


    static void BattleUnits(Unit attacker, Unit defender, StreamWriter sw)
    {
        //Console.WriteLine($"Players {attacker.Name} attacks {defender.Name}!");
        sw.WriteLine($"Players {attacker.Name} attacks {defender.Name}!");

        // Check if the pets will kill each other
        int damageToDefender = attacker.Attack;
        int damageToAttacker = defender.Attack;

        defender.Health -= damageToDefender;
        attacker.Health -= damageToAttacker;

        // Log the damage dealt
        //Console.WriteLine($"Players {attacker.Name} deals {damageToDefender} damage to Enemies {defender.Name}");
        sw.WriteLine($"Players {attacker.Name} deals {damageToDefender} damage to Enemies {defender.Name}");

        //Console.WriteLine($"Enemies {defender.Name} deals {damageToAttacker} damage to {attacker.Name}");
        sw.WriteLine($"Enemies {defender.Name} deals {damageToAttacker} damage to Players{attacker.Name}");

        // Check and log abilities triggered
        //if (!string.IsNullOrEmpty(attacker.AbilityTrigger))
        //{
        //    Console.WriteLine($"Players {attacker.Name}'s ability triggered: {attacker.AbilityTrigger}");
        //    sw.WriteLine($"Players {attacker.Name}'s ability triggered: {attacker.AbilityTrigger}");
        //    TriggerAbility(attacker, defender);
        //}

        //if (!string.IsNullOrEmpty(defender.AbilityTrigger))
        //{
        //    Console.WriteLine($"Enemies {defender.Name}'s ability triggered: {defender.AbilityTrigger}");
        //    sw.WriteLine($"Enemies {defender.Name}'s ability triggered: {defender.AbilityTrigger}");
        //    TriggerAbility(defender, attacker);
        //}
    }

    static void AdjustPositions(List<Unit> units)
    {
        // Sort units by position in descending order
        units = units.OrderByDescending(u => u.Position).ToList();

        // Update positions
        for (int i = 0; i < units.Count; i++)
        {
            units[i].Position = i;
        }
    }

    static void TriggerAbility(Unit unitWithAbility, Unit target)
    {
        // Implement your ability logic here based on the unit's ability
        // For example, you can modify health, attack, or other properties
    }
}

class Unit
{
    public string Name { get; set; } = "Ant";
    public int Attack { get; set; } = 2;
    public int Health { get; set; } = 2;
    public int Tier { get; set; } = 1;

    //add ability logic here?
    public string AbilityTrigger { get; set; } = "Faint";

    public int Cost { get; set; } = 3;
    public int Sell { get; set; } = 1;
    public string Pack { get; set; } = "Turtle";
    public int Position { get; set; } = 0; // Added Position property

    public Unit(string name, int attack, int health, int tier, string abilityTrigger, int cost, int sell, string pack)
    {
        Name = name;
        Attack = attack;
        Health = health;
        Tier = tier;
        AbilityTrigger = abilityTrigger;
        Cost = cost;
        Sell = sell;
        Pack = pack;
    }

    public void AttackUnit(Unit target)
    {
        target.Health -= this.Attack;
    }

}
