using SuperAutoSimulator;
using static SuperAutoSimulator.SuperAutoSimulator;

class Shop
{
    static public List<Pet> potentialPets = new List<Pet>();
    static public List<Pet> NextLevelPets = new List<Pet>();
    public static void RunShopPhase()
    {
        executeShopCode();
        //playerPets = LoadRandomPets(5, CurrentTier);
        enemyPets = LoadRandomPets(5, CurrentTier);
    }
    public static void executeShopCode()
    {
        //check if we upgrade the shop
        if (isOdd(gameNumber) && gameNumber < 12)
        {
            CurrentTier++;
            playerCoins = 10;
            ShopInventory = LoadRandomPets(5, CurrentTier);
            InOut.DisplayPets("Player");
            InOut.DisplayPets("Shop");
            InOut.ShopInput();
        }

        //ShopInventory

    }
    public static void buyPet(int buy, int pos)
    {

            playerPets.Insert(pos, ShopInventory[buy]);
            InOut.DisplayPets("Player");
    }
    public static List<Pet> LoadRandomPets(int petcount, int? tier)
    {
        //pick a better sorting algorythm, maybe 
        List<Pet> resultPets = new List<Pet>();
        for (int i = 0; i < allPets.Count; i++)
        {
            if (allPets[i].Tier <= tier)
            {
                potentialPets.Add(allPets[i]);
            }
            if (allPets[i].Tier == tier + 1)
            {
                NextLevelPets.Add(allPets[i]);
            }
        }

        for (int i = 1; i <= petcount; i++)
        {
            Pet randomPet = potentialPets[rnd.Next(potentialPets.Count)];
            randomPet.Position = resultPets.Count;
            resultPets.Add(new Pet(randomPet)); // Create a new instance of Pet
        }

        return resultPets;
    }

}
