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
                InOut.LoseOutput("Player");
                playerPets.Remove(playerPet);
                AdjustPositions(playerPets);
            }

            // Check if enemy's Pet is defeated
            if (enemyPet.Health <= 0)
            {
                InOut.LoseOutput("Owner");
                enemyPets.Remove(enemyPet);
                AdjustPositions(enemyPets);
            }

            // Log Pet status after the battle
            InOut.DisplayPets("Player");
            InOut.DisplayPets("Enemy");

            InOut.EndTurn();
        }
        displayVictor(playerPets, enemyPets);
    }

    static void displayVictor(List<Pet> pp, List<Pet> ep)
    {

        // Display the winner
        if (!pp.Any() && !ep.Any())
        {
            playerDraws++;
            InOut.RoundResult("draw");
        }
        else if (ep.Any())
        {
            enemyWins++;
            InOut.RoundResult("lose");
            hearts--;
        }
        else if (pp.Any())
        {
            playerWins++;
            InOut.RoundResult("win");
            starsOwned++;
        }
        InOut.GameCount();
        gameNumber++;
    }
    static void battleindividualPets(Pet attacker, Pet defender)
    {

        // Check if the pets will kill each other
        int damageToDefender = attacker.Attack;
        int damageToAttacker = defender.Attack;

        defender.Health -= damageToDefender;
        attacker.Health -= damageToAttacker;

        // Log the damage dealt
        InOut.battleEvents(attacker, defender, damageToAttacker, damageToDefender);
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
