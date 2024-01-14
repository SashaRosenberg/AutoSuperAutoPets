using SuperAutoSimulator;
using static SuperAutoSimulator.SuperAutoSimulator;

class Shop
{
    static public List<Pet> potentialPets = new List<Pet>();
    static public List<Pet> NextLevelPets = new List<Pet>();
    public static void RunShopPhase()
    {
        generateWhiteSpace();

        executeShopCode();

        //playerPets = LoadRandomPets(5, CurrentTier);
        enemyPets = LoadRandomPets(5, CurrentTier);
    }
    static void generateWhiteSpace()
    {
        if (playerPets.Any() == false)
        {
            for (int i = 0; i <= 4; i++)
            {
                playerPets.Insert(i, new Pet());
            }
        }
        else
        {
            for (int n = 0;  n < playerPets.Count;  n++)
            {
                playerPets[n].Position = n;
            }
        }
    }

    public static void executeShopCode()
    {
        //check if we upgrade the shop
        if (isOdd(gameNumber) && gameNumber < 12)
        {
            CurrentTier++;
        }
        playerCoins = 10;
        ShopInventory = LoadRandomPets(5, CurrentTier);
        InOut.DisplayPets("Player");
        InOut.DisplayPets("Shop");
        InOut.ShopInput();

        //ShopInventory

    }
    public static void SellPet(int pos)
    {
        if (playerPets[pos].Name == "-")
        {
            InOut.FailedPurchase("NAP");
        }
        else if (playerPets[pos].Name != "-")
        {
            playerCoins = playerCoins + playerPets[pos].Sell;
            playerPets.Remove(playerPets[pos]);
            playerPets.Insert(pos, new Pet());
            playerPets[pos].Position = pos;
        }

    }
    public static void buyPet(int buy, int pos)
    {
        if (ShopInventory[buy].Name == "-")
        {
            InOut.FailedPurchase("NAP");
        }
        else if (ShopInventory[buy].Cost > playerCoins)
        {
            InOut.FailedPurchase("NAP"); //change this to a coin specific varient
        }
        else if (playerPets[pos].Name == "-")
        {
            playerPets.Remove(playerPets[pos]);
            playerCoins = playerCoins - ShopInventory[buy].Cost;
            playerPets.Insert(pos, ShopInventory[buy]);
            playerPets[pos].Position = pos;

            ShopInventory.Remove(ShopInventory[buy]);
            ShopInventory.Insert(buy, new Pet());
            ShopInventory[buy].Position = buy;
            InOut.DisplayPets("Player");
        }
        else if (playerPets[pos].Name != "-")
        {
            InOut.FailedPurchase("NAP"); //make space occupied code

        }

    }
    public static void MovePet(int pet, int newPos)
    {
        Pet p = new Pet();
        Pet p2 = new Pet();
        if (playerPets[pet].Name == "-")
        {
            //put input code here
        }
        else
        {
            p = new Pet(playerPets[pet]);
            p2 = new Pet(playerPets[newPos]);
            playerPets.Remove(playerPets[pet]);
            playerPets.Remove(playerPets[newPos]);

            playerPets.Insert(pet, p);
            playerPets[pet].Position = p.Position;

            playerPets.Insert(newPos, p2);
            playerPets[newPos].Position = p.Position;

        }
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
