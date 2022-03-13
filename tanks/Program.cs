using System;

namespace tanks
{
    class Program
    {
        static string[,] battlefield = new string[8, 8];
        static void PlaceTanks() //randomly distributes tanks across the game field
        {
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int c1 = rnd.Next(0, 8);
                int c2 = rnd.Next(0, 8);
                if (battlefield[c1, c2] != "T")
                {
                    battlefield[c1, c2] = "T";
                }
            }
        }
        static void HitDetection() //gets input and checks if the player has hit a tank
        {
            int attempts = 0;
            int coord1;
            int coord2;
            int tanksHit = 0;
            do
            {
                Console.WriteLine("SCORE = {0} ATTEMPTS = {1}", tanksHit, attempts);
                Console.WriteLine("Enter co-ords to shoot:");
                coord1 = int.Parse(Console.ReadLine()) - 1;
                coord2 = int.Parse(Console.ReadLine()) - 1; //zero input validation :)))))
                if (battlefield[coord1, coord2] == "T")
                {
                    tanksHit++;
                    attempts++;
                    Console.WriteLine("Tank destroyed!");
                }
                else
                {
                    attempts++;
                    Console.WriteLine("Missed!");
                }
                Console.WriteLine("PRESS ENTER TO CONTINUE");
                Console.ReadLine();
                Console.Clear();
            } while (attempts <= 50 || tanksHit == 50);
            EndGame(tanksHit, attempts);
        }
        static void StartGame() //sets window size and displays menu text
        {
            Console.WindowWidth = 25;
            Console.WindowHeight = 13;
            Console.Clear();
            Console.WriteLine("      ~ T A N K S ~");
            Console.WriteLine("10 enemy tanks have been");
            Console.WriteLine("placed on a 8x8 grid.");
            Console.WriteLine("Your task is to destroy");
            Console.WriteLine("each one within 50 turns.");
            Console.WriteLine();
        }
        static void EndGame(int tanksHit, int attempts) //displays results
        {
            if (tanksHit == 50)
            {
                Console.WriteLine("    ~ V I C T O R Y ~");
                Console.WriteLine();
                Console.WriteLine("You have vanquished all");
                Console.WriteLine("the enemy tanks within 50");
                Console.WriteLine("turns! Well done!");
                Console.WriteLine();
                Console.WriteLine("       YOUR SCORE");
                Console.WriteLine(" {0} tanks in {1} turns", tanksHit, attempts);
                Console.WriteLine();
                Console.WriteLine("PRESS ENTER TO PLAY AGAIN");
                Console.ReadLine();
                StartGame();
            }
            else if (attempts == 50)
            {
                Console.WriteLine("    ~ F A I L U R E ~");
                Console.WriteLine();
                Console.WriteLine("You failed to destroy all");
                Console.WriteLine("the enemy tanks within 50");
                Console.WriteLine("turns. Try again.");
                Console.WriteLine();
                Console.WriteLine("       YOUR SCORE");
                Console.WriteLine(" {0} tanks in {1} turns", tanksHit, attempts);
                Console.WriteLine();
                Console.WriteLine("PRESS ENTER TO PLAY AGAIN");
                Console.ReadLine();
                StartGame();
            }
        }
        static void Main(string[] args) //does the stuff and the things
        {
            StartGame();
            PlaceTanks();
            HitDetection();
        }
    }
}