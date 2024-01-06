using static SuperAutoSimulator.SuperAutoSimulator;

class Shop
{
    public static void RunShopPhase()
    {
        playerPets = LoadRandomPets(5);
        enemyPets = LoadRandomPets(5);
    }
    
    public static List<Pet> LoadRandomPets(int count)
    {
        List<Pet> resultPets = new List<Pet>();

        //resultPets.Clear();
        for (int i = 1; i <= count; i++)
        {
            Pet randomPet = allPets[rnd.Next(allPets.Count)];
            randomPet.Position = resultPets.Count;
            resultPets.Add(new Pet(randomPet)); // Create a new instance of Pet
        }

        return resultPets;
    }

}
