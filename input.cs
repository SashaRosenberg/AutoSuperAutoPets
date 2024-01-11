using SuperAutoSimulator;
using static SuperAutoSimulator.SuperAutoSimulator;
using System.Drawing;

namespace SuperAutoSimulator
{
    static class InOut
    {
        public static void ShopInput()
        {
            string userInput;
            bool runningShop = true;
            while (runningShop)
            {
                drawShop();

                userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "Buy":
                        Console.Clear();
                        BuyMenu();
                        break;

                    case "Sell":
                        break;

                    case "Move":
                        break;

                    case "Roll":
                        Console.Clear();
                        Shop.LoadRandomPets(5, CurrentTier);
                        DisplayPets("Shop");
                        break;

                    case "End Turn":
                        runningShop = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("i dont have a SPELL READY");
                        Console.WriteLine("please select a valid option\n-------------------------------------------------------");
                        break;

                }
            }
        }
        public static void FailedPurchase(string reason)
        {
            switch (reason)
            {
                case "NAP":
                    Console.WriteLine("you know what you did :(");
                    break;
            }
        }
        public static void BuyMenu()
        {
            string userInput;
            bool RunningBuy = true, RunningBuy2 = false;
            int choice = -1;
            Console.WriteLine("Please pick who you would like to buy\n");

            while (RunningBuy)
            {
                DisplayPets("Shop");
                Console.WriteLine("--Back--");
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        choice = 1 + -1;
                        RunningBuy2 = true;
                        RunningBuy = false;
                        break;

                    case "2":
                        choice = 2 + -1;
                        RunningBuy2 = true;
                        RunningBuy = false;
                        break;

                    case "3":
                        choice = 3 + -1;
                        RunningBuy2 = true; 
                        RunningBuy = false;
                        break;

                    case "4":
                        choice = 4 + -1;
                        RunningBuy2 = true;
                        RunningBuy = false;

                        break;

                    case "5":
                        choice = 5 + -1;
                        RunningBuy2 = true;
                        RunningBuy = false;

                        break;

                    case "Back":
                        RunningBuy = false;
                        RunningBuy2 = false;
                        break;

                    default:
                        Console.WriteLine("i dont have a SPELL READY");
                        break;
                }
                while (RunningBuy2)
                {
                    Console.WriteLine("where would you like them?\nCURRENT TEAM\n");
                    DisplayPets("Player");
                    Console.WriteLine("--Back--");

                    userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            Shop.buyPet(choice, 1 + -1);
                            RunningBuy2 = false;
                            break;

                        case "2":
                            Shop.buyPet(choice, 2 + -1);
                            RunningBuy2 = false;
                            break;

                        case "3":
                            Shop.buyPet(choice, 3 + -1);
                            RunningBuy2 = false;
                            break;

                        case "4":
                            Shop.buyPet(choice, 4 + -1);
                            RunningBuy2 = false;
                            break;

                        case "5":
                            Shop.buyPet(choice, 5 + -1);
                            RunningBuy2 = false;
                            break;

                        case "Back":
                            RunningBuy = true;
                            RunningBuy2 = false;
                            break;

                        default:
                            Console.WriteLine("i dont have a SPELL READY");
                            break;
                    }
                }

            }

        }
        public static void DisplayPets(string owner)
        {
            Color color = Color.White;
            string result = $"{owner}'s Pets: \n";
            if (owner == "Player")
            {
                color = Color.Blue;
                foreach (var Pet in playerPets)
                {
                    result += $"{Pet.Position + 1} - {Pet.Name}, Health: {Pet.Health}, Attack: {Pet.Attack}, Position: {Pet.Position}\n";
                }
            }
            else if (owner == "Enemy")
            {
                color = Color.Red;
                foreach (var Pet in playerPets)
                {
                    result += $"{Pet.Name}, Health: {Pet.Health}, Attack: {Pet.Attack}, Position: {Pet.Position}\n";
                }
            }
            else if (owner == "Shop")
            {
                color = Color.Yellow;
                result = "Shop Pets Avaliable: \n";

                foreach (var Pet in ShopInventory)
                {
                    result += $"{Pet.Position + 1} - {Pet.Name}, Health: {Pet.Health}, Attack: {Pet.Attack}, Cost: {Pet.Cost}\n";
                }
            }

            Console.WriteLine(result, color);

        }
        public static void EndTurn()
        {
            Console.WriteLine("\n--- Next Turn ---");
        }
        public static void Display2PetsForBattle(Pet pP, Pet eP)
        {
            Console.WriteLine($"Players's Pet: {pP.Name}, Health: {pP.Health}, Attack: {pP.Attack}, Position: {pP.Position} \n");
            Console.WriteLine("VS\n", Color.Green);
            Console.WriteLine($"Enemy's Pet: {eP.Name}, Health: {eP.Health}, Attack: {eP.Attack}, Position: {eP.Position} \n");


        }
        public static void DisplayRoundStats()
        {
            Console.WriteLine(
            $"\n" +
            $"Player Wins: {playerWins}\n" +
            $"Enemy Wins: {enemyWins}\n" +
            $"playerDraws: {playerDraws}\n" +
            $"Player Stars: {starsOwned}\n" +
            $"Player Hearts: {hearts}\n" +
            $"\n");

        }
        public static void RoundResult(string result)
        {
            switch (result)
            {
                case "win":
                    Console.WriteLine("\nPlayer wins!");
                    break;

                case "lose":
                    Console.WriteLine("\nEnemy wins!");
                    break;

                case "draw":
                    Console.WriteLine("\nDRAW!");
                    break;
            }
        }
        public static void LoseOutput(string owner)
        {
            Console.WriteLine($"{owner} Pet defeated!");

        }
        public static void battleEvents(Pet aP, Pet dP, int D2A, int D2D)
        {
            Console.WriteLine($"Players {aP.Name} deals {D2D} damage to Enemies {dP.Name}");
            Console.WriteLine($"Enemies {dP.Name} deals {D2A} damage to {aP.Name}");

        }
        public static void GameCount()
        {
            Console.WriteLine($"\nGamecounter: {gameNumber}\n");
        }
        public static void GameOver(string result)
        {
            if (result == "win")
            {
                Console.WriteLine("Player Wins");

            }
            else if (result == "lose")
            {
                Console.WriteLine("player Eliminated");

            }
        }
        public static void isOdd(bool result, int n)
        {
            if (!result)
            {
                Console.WriteLine($"{n} is not odd");
            }
            else if (result)
            {
                Console.WriteLine($"{n} is odd");
            }
        }
        public static void drawShop()
        {
            PlayerStats();
            Console.WriteLine("\n" +
                "Welcome to the shop!\n" +
                "Buy - choose a pet to buy\n" +
                "Sell - sell one of your pets\n" +
                "Move - Move your pets around\n" +
                "Roll - Pay 1 coin to refresh pets in the shop\n" +
                "End Turn - Fight!\n");
            Console.WriteLine("--Back--");
        }
        public static void PlayerStats()
        {
            Console.WriteLine($"\n" +
                $"Hearts: {hearts}\n" +
                $"Coins: {playerCoins}\n" +
                $"Stars: {starsOwned}\n" +
                $"Round: {gameNumber}" +
                $"Shop Tier: {CurrentTier}");
        }
    }
}
