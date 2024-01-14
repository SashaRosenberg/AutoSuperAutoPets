using SuperAutoSimulator;
using static SuperAutoSimulator.SuperAutoSimulator;
class Battle
{
    public static List<Pet> PetsFighting = new List<Pet>();
    public static void StartBattlePhase()
    {
        for(int i = 0; playerPets.Count > i; i++)
        {
            PetsFighting.Add(new Pet(playerPets[i])); // Create a new instance of Pet

        }
        //remove number of battles
        turnCounter = 0;
        MovePetsForward(); // add a section to move enemy pets forward too
        InOut.DisplayPets("PlayerFighting");
        InOut.DisplayPets("Enemy");

        // Simulate a battle
        simulateBattle(PetsFighting, enemyPets);

    }
    static void MovePetsForward()
    {
        for(int n = 0; n < PetsFighting.Count; n++)
        {
            if (PetsFighting[n].Name == "-")
            {
                PetsFighting.RemoveAt(n);
                n = -1;
            }
            InOut.DisplayPets("PlayerFighting");
        }
        for(int n = 0; n < PetsFighting.Count; n++)
        {
            PetsFighting[n].Position = n;
        }
    }
    static void simulateBattle(List<Pet> pP, List<Pet> eP)
    {
        while (pP.Any() && eP.Any())
        {
            //turnCounter++;


            // Get the first pet from both player and enemy Pets
            Pet playerPet = pP.First();
            Pet enemyPet = eP.First();

            // Display Pet status
            InOut.Display2PetsForBattle(playerPet, enemyPet); //merge these two functions?


            // Check if the pets will kill each other
            battleindividualPets(playerPet, enemyPet);

            // Check if player's Pet is defeated
            if (playerPet.Health <= 0)
            {
                InOut.LoseOutput("PlayerFighting");
                pP.Remove(playerPet); //change this somewhat
                AdjustPositions(PetsFighting);
            }

            // Check if enemy's Pet is defeated
            if (enemyPet.Health <= 0)
            {
                InOut.LoseOutput("Owner");
                eP.Remove(enemyPet);
                AdjustPositions(eP);
            }

            // Log Pet status after the battle
            InOut.DisplayPets("PlayerFighting");
            InOut.DisplayPets("Enemy");

            InOut.EndTurn();
        }
        displayVictor(pP, eP); //change this
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
