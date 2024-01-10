using Newtonsoft.Json;

namespace SuperAutoSimulator
{
    class SuperAutoSimulator
    {
        //Create game tracker\\
        public static int playerWins = 0;
        public static int enemyWins = 0;
        public static int playerDraws = 0;
        public static int turnCounter = 1; //currently unused
        public static int gameNumber = 1;
        public static int starsOwned = 0;
        public static int hearts = 500; //5 is the default
        public static int CurrentTier = 0;
        public static int CrownTracker = 0;

        //Set game rules\\
        public static List<Pet> allPets;
        //static double elapsedSeconds;
        static long numberOfBattles = 1; //1 is default gameplay loop, bigger is for testing ONLY
        static public Random rnd = new Random();

        //Stores both players lists\\
        public static List<Pet> playerPets = new List<Pet>();
        public static List<Pet> enemyPets = new List<Pet>();
        public static List<Pet> ShopInventory = new List<Pet>();

        static void Main()
        {
            string logFilePath = $"GameLog.txt"; //replace this with a dedicated function
            string logFilePath2 = $"WLD.txt"; //replace this with a dedicated function
            string logFilePath3 = $"TTC.txt"; //replace this with a dedicated function

            void restartGame()
            {
                //clear the two players of their teams
                enemyPets.Clear();
                playerPets.Clear();

                //clear the shop
                CurrentTier = 0;
                ShopInventory.Clear();
                gameNumber = 1;
                playerWins = 0;
                enemyWins = 0;
                //clear player stats
                hearts = 5;
                starsOwned = 0;

                //generate pets
                GeneratePets();
            }

            //create parent pet list\\

            for (int i = 0; i < numberOfBattles; i++)
            {
                restartGame();
                while (hearts >= 1 && starsOwned <= 10)
                {
                    //enter shop phase\\
                    Shop.RunShopPhase();

                    //enter battle phase\\
                    Battle.StartBattlePhase();

                    InOut.DisplayRoundStats();
                }
                if (starsOwned >= 10)
                {
                    Console.WriteLine("Player Wins");
                }
                else if (hearts >= 0)
                {
                    Console.WriteLine("player Eliminated");
                }
            }
        }


        static List<Pet> LoadPetsFromJson(string jsonFilePath)
        {
            string json = File.ReadAllText(jsonFilePath);
            return JsonConvert.DeserializeObject<List<Pet>>(json);
        }
        static void GeneratePets()
        {
            allPets = LoadPetsFromJson("Pets.json");

        }
        public static void TriggerAbility(Pet PetWithAbility, Pet target)
        {

        }

        public static bool isOdd(int n)
        {
            int r = n % 2;
            if (r == 0)
            {
                Console.WriteLine($"{n} is not odd");
                return
                    false;
            }
            else
            {
                Console.WriteLine($"{n} is odd");

                return
                    true;
            }
        }
        public static int binarySearch(int[] arr, int x)
        {
            int l = 0, r = arr.Length - 1;
            while (l <= r)
            {
                int m = l + (r - l) / 2;

                // Check if x is present at mid
                if (arr[m] == x)
                    return m;

                // If x greater, ignore left half
                if (arr[m] < x)
                    l = m + 1;

                // If x is smaller, ignore right half
                else
                    r = m - 1;
            }

            // If we reach here, then element was
            // not present
            return -1;

        }
    }
}