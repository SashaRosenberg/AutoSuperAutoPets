using static SuperAutoSimulator.SuperAutoSimulator;

class Battle
{
    public static void StartBattlePhase(StreamWriter sw)
    {

        //remove number of battles
        turnCounter = 0;

        //Console.WriteLine("Player's Pets:");
        DisplayPets(playerPets, "Player");

        //Console.WriteLine("\nEnemy's Pets:");
        DisplayPets(enemyPets, "Enemy");

        // Simulate a battle
        simulateBattle(playerPets, enemyPets, sw);
    }


    static void simulateBattle(List<Pet> playerPets, List<Pet> enemyPets, StreamWriter sw)
    {

        sw.WriteLine("--- Battle Log ---");
        while (playerPets.Any() && enemyPets.Any())
        {
            //turnCounter++;

            // Log turn counter
            sw.WriteLine($"\nTurn {turnCounter}:");

            // Get the first pet from both player and enemy Pets
            Pet playerPet = playerPets.First();
            Pet enemyPet = enemyPets.First();

            // Display Pet status
            //Console.WriteLine($"\nPlayer's Pet: {playerPet.Name}, Health: {playerPet.Health}, Attack: {playerPet.Attack}, Position: {playerPet.Position}");
            sw.WriteLine($"\nPlayer's Pet: {playerPet.Name}, Health: {playerPet.Health}, Attack: {playerPet.Attack}, Position: {playerPet.Position}");

            //Console.WriteLine($"Enemy's Pet: {enemyPet.Name}, Health: {enemyPet.Health}, Attack: {enemyPet.Attack}, Position: {enemyPet.Position}");
            sw.WriteLine($"Enemy's Pet: {enemyPet.Name}, Health: {enemyPet.Health}, Attack: {enemyPet.Attack}, Position: {enemyPet.Position}");

            // Check if the pets will kill each other
            battleindividualPets(playerPet, enemyPet, sw);

            // Check if player's Pet is defeated
            if (playerPet.Health <= 0)
            {
                //Console.WriteLine("Player Pet defeated!");
                sw.WriteLine("Player Pet defeated!");
                playerPets.Remove(playerPet);
                AdjustPositions(playerPets);
            }

            // Check if enemy's Pet is defeated
            if (enemyPet.Health <= 0)
            {
                //Console.WriteLine("Enemy Pet defeated!");
                sw.WriteLine("Enemy Pet defeated!");
                enemyPets.Remove(enemyPet);
                AdjustPositions(enemyPets);
            }

            // Log Pet status after the battle
            //Console.WriteLine("\nPlayer's Pets:");
            DisplayPets(playerPets, "Player");
            sw.WriteLine("\nPlayer's Pets:");
            foreach (var Pet in playerPets)
            {
                sw.WriteLine($"{Pet.Name}, Health: {Pet.Health}, Attack: {Pet.Attack}");
            }

            //Console.WriteLine("\nEnemy's Pets:");
            DisplayPets(enemyPets, "Enemy");
            sw.WriteLine("\nEnemy's Pets:");
            foreach (var Pet in enemyPets)
            {
                sw.WriteLine($"{Pet.Name}, Health: {Pet.Health}, Attack: {Pet.Attack}");
            }

            //Console.WriteLine("\n--- Next Turn ---");
            sw.WriteLine("\n--- Next Turn ---");
        }
        displayVictor(playerPets, enemyPets, sw);
    }

    static void displayVictor(List<Pet> pp, List<Pet> ep, StreamWriter sw)
    {

        // Display the winner
        if (!pp.Any() && !ep.Any())
        {
            playerDraws++;
            //Console.WriteLine("\nDRAW!");
            sw.WriteLine("\nDRAW!");
        }
        else if (ep.Any())
        {
            enemyWins++;
            //Console.WriteLine("\nEnemy wins!");
            sw.WriteLine("\nEnemy wins!");
            hearts--;
        }
        else if (pp.Any())
        {
            playerWins++;
            //Console.WriteLine("\nPlayer wins!");
            sw.WriteLine("\nPlayer wins!");
            starsOwned++;
        }

        //enter shop phase\\

        //Console.WriteLine($"\nGamecounter: {gameNumber}\n");
        sw.WriteLine($"\nGamecounter: {gameNumber}\n");
        gameNumber++;
    }
    static void battleindividualPets(Pet attacker, Pet defender, StreamWriter sw)
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
        sw.WriteLine($"Enemies {defender.Name} deals {damageToAttacker} damage to Players {attacker.Name}");

        // Check and log abilities triggered
        //if (!string.IsNullOrEmpty(attacker.AbilityTrigger))
        //{
        //    //Console.WriteLine($"Players {attacker.Name}'s ability triggered: {attacker.AbilityTrigger}");
        //    sw.WriteLine($"Players {attacker.Name}'s ability triggered: {attacker.AbilityTrigger}");
        //    TriggerAbility(attacker, defender);
        //}

        //if (!string.IsNullOrEmpty(defender.AbilityTrigger))
        //{
        //    //Console.WriteLine($"Enemies {defender.Name}'s ability triggered: {defender.AbilityTrigger}");
        //    sw.WriteLine($"Enemies {defender.Name}'s ability triggered: {defender.AbilityTrigger}");
        //    TriggerAbility(defender, attacker);
        //}
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
