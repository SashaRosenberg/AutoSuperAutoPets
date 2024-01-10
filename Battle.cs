using Microsoft.VisualBasic;
using SuperAutoSimulator;
using System.Drawing;
using static SuperAutoSimulator.SuperAutoSimulator;
class Battle
{
    public static void StartBattlePhase()
    {
        //remove number of battles
        turnCounter = 0;
        InOut.DisplayPets("Player");
        InOut.DisplayPets("Enemy");

        // Simulate a battle
        simulateBattle(playerPets, enemyPets);

    }
    static void simulateBattle(List<Pet> playerPets, List<Pet> enemyPets)
    {

        while (playerPets.Any() && enemyPets.Any())
        {
            //turnCounter++;


            // Get the first pet from both player and enemy Pets
            Pet playerPet = playerPets.First();
            Pet enemyPet = enemyPets.First();

            // Display Pet status
            InOut.Display2PetsForBattle(playerPet, enemyPet);

            // Check if the pets will kill each other
            battleindividualPets(playerPet, enemyPet);

            // Check if player's Pet is defeated
            if (playerPet.Health <= 0)
            {
                Console.WriteLine("Player Pet defeated!");
                playerPets.Remove(playerPet);
                AdjustPositions(playerPets);
            }

            // Check if enemy's Pet is defeated
            if (enemyPet.Health <= 0)
            {
                Console.WriteLine("Enemy Pet defeated!");
                enemyPets.Remove(enemyPet);
                AdjustPositions(enemyPets);
            }

            // Log Pet status after the battle
            InOut.DisplayPets("Player");
            InOut.DisplayPets("Enemy");

            Console.WriteLine("\n--- Next Turn ---"); //change this?
        }
        displayVictor(playerPets, enemyPets);
    }

    static void displayVictor(List<Pet> pp, List<Pet> ep)
    {

        // Display the winner
        if (!pp.Any() && !ep.Any())
        {
            playerDraws++;
            Console.WriteLine("\nDRAW!");
        }
        else if (ep.Any())
        {
            enemyWins++;
            Console.WriteLine("\nEnemy wins!");
            hearts--;
        }
        else if (pp.Any())
        {
            playerWins++;
            Console.WriteLine("\nPlayer wins!");
            starsOwned++;
        }

        //enter shop phase\\

        Console.WriteLine($"\nGamecounter: {gameNumber}\n");
        gameNumber++;
    }
    static void battleindividualPets(Pet attacker, Pet defender)
    {

        //input.($"Players {attacker.Name} attacks {defender.Name}!");
        // Check if the pets will kill each other
        int damageToDefender = attacker.Attack;
        int damageToAttacker = defender.Attack;

        defender.Health -= damageToDefender;
        attacker.Health -= damageToAttacker;

        // Log the damage dealt
        Console.WriteLine($"Players {attacker.Name} deals {damageToDefender} damage to Enemies {defender.Name}");
        Console.WriteLine($"Enemies {defender.Name} deals {damageToAttacker} damage to {attacker.Name}");
    }

    static void AdjustPositions(List<Pet> Pets)
    {
        // Update positions
        for (int i = 0; i < Pets.Count; i++)
        {
            Pets[i].Position = i;
        }
    }

}
