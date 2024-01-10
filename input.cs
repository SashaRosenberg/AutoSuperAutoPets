using SuperAutoSimulator;
using static SuperAutoSimulator.SuperAutoSimulator;
using System.Drawing;

namespace SuperAutoSimulator
{
    static class InOut
    {
        public static void interact(string caller, string content, Color c)
        {
            switch (caller)
            {
                case "battleEvents":
                    battleEvents(content, c);
                    break;
                case "displayPets":
                    break;
                case "viewShopPets":
                    break;
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
                    result += $"{Pet.Name}, Health: {Pet.Health}, Attack: {Pet.Attack}, Position: {Pet.Position}\n";
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
                result = $"Shop Tier: {CurrentTier} \n";
                result = "Shop Pets Avaliable: \n";

                foreach (var Pet in ShopInventory)
                {
                    result += $"{Pet.Name}, Health: {Pet.Health}, Attack: {Pet.Attack}, Position: {Pet.Position}\n";
                }
            }

            Console.WriteLine(result, color);
        }

        //this code might be used for shop related things.

        //public static void DisplayPet(Pet p)
        //{
        //    Console.WriteLine($"{owner}'s Pet: {p.Name}, Health: {p.Health}, Attack: {p.Attack}, Position: {p.Position} \n");
        //}
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
        static void battleEvents(string bE, Color c)
        {
            Console.WriteLine("test", c);
            Console.WriteLine(bE);
        }
    }
}
