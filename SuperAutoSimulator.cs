using Newtonsoft.Json;
using System.Diagnostics;

namespace SuperAutoSimulator
{
    class SuperAutoSimulator
    {
        //Create game tracker\\
        public static int playerWins = 0;
        public static int enemyWins = 0;
        public static int playerDraws = 0;
        public static int turnCounter = 1;
        public static int gameNumber = 1;
        public static int starsOwned = 0;
        public static int hearts = 5;


        //Set game rules\\
        public static List<Pet> allPets;
        static double elapsedSeconds;
        static long numberOfBattles = 10000;
        static public Random rnd = new Random();

        //Stores both players lists\\
        public static List<Pet> playerPets = new List<Pet>();
        public static List<Pet> enemyPets = new List<Pet>();
        public static List<Pet> Shop = new List<Pet>();

        static void Main()
        {
            string logFilePath = $"GameLog.txt"; //replace this with a dedicated function
            string logFilePath2 = $"WLD.txt"; //replace this with a dedicated function
            string logFilePath3 = $"TTC.txt"; //replace this with a dedicated function

            var watch = new Stopwatch();

            //create parent pet list\\
            GeneratePets();

            using (StreamWriter sw3 = new StreamWriter(logFilePath3))
            {
                using (StreamWriter sw = new StreamWriter(logFilePath))
                {
                    for (int i = 0; i < numberOfBattles; i++)
                    {

                        enemyPets.Clear();
                        playerPets.Clear();
                        hearts = 5;
                        starsOwned = 0;
                        while (hearts >= 1 && starsOwned <= 11)
                        {
                            watch.Start();

                            //enter shop phase\\
                            Shop.RunShopPhase();

                            //enter battle phase\\
                            Battle.StartBattlePhase(sw);
                            watch.Stop();

                            elapsedSeconds = (double)watch.ElapsedTicks / Stopwatch.Frequency;

                            sw.WriteLine(
                               $"Player Wins: {playerWins}\n" +
                               $"Enemy Wins: {enemyWins}\n" +
                               $"playerDraws: {playerDraws}\n" +
                               $"Player Stars: {starsOwned}\n" +
                               $"Player Stars: {hearts}\n" +
                               $"\n" +
                               $"Time To Compute: {elapsedSeconds} seconds");
                            //Console.WriteLine(
                            //   $"Player Wins: {playerWins}\n" +
                            //   $"Enemy Wins: {enemyWins}\n" +
                            //$"playerDraws: {playerDraws}\n" +
                            //$"Player Stars: {starsOwned}\n" +
                            //$"Player Hearts: {hearts}\n" +
                            //$"\n" +
                            //$"Time To Compute: {elapsedSeconds} seconds");
                        }
                        sw3.WriteLine($"{elapsedSeconds}\n");

                        using (StreamWriter sw2 = new StreamWriter(logFilePath2))
                        {
                            sw2.WriteLine(
                                $"Player Wins: {playerWins}\n" +
                                $"Enemy Wins: {enemyWins}\n" +
                                $"playerDraws: {playerDraws}\n");
                        }
                    }
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

        public static void DisplayPets(List<Pet> PetList, string owner)
        {
            foreach (var Pet in PetList)
            {
                //Console.WriteLine($"{owner}'s {Pet.Name}, Health: {Pet.Health}, Attack: {Pet.Attack}, Position: {Pet.Position}");
            }
        }

        public static void TriggerAbility(Pet PetWithAbility, Pet target)
        {
            // Implement your ability logic here based on the Pet's ability
            // For example, you can modify health, attack, or other properties
        }
    }
}