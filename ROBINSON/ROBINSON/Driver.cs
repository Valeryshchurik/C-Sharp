using System;
using System.IO;
using ISO_Robinson.Game;

namespace ISO_Robinson
{
    public class Driver
    {
        public static void Main()
        {
            int[,] matrix = { { 1, 2, 4 },
                              { 4, 2, 1 }};
            GameEngine game = new GameEngine(200000, matrix);
            GetGameHistory(game);
            GetGameResult(game);
        }

        private static void GetGameHistory(GameEngine game)
        {
            using (var writer = new StreamWriter("gamehistory.txt"))
            {
                foreach (string s in game.GameHistory)
                {
                    writer.WriteLine(s);
                }
            }
        }

        private static void GetGameResult(GameEngine game)
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ RESULT OF GAME ~~~~~~~~~~~~~~~~~~~~~~~~");
            string delimeter = $"/{game.CountOfParties}, ";
            Console.Write("The statistic of First Player is - ({0}", string.Join(delimeter, game.StrategyA));
            Console.WriteLine("/{0})", game.CountOfParties);
            Console.Write("The statistic of Secnd Player is - ({0}", string.Join(delimeter, game.StrategyB));
            Console.WriteLine("/{0})", game.CountOfParties);
            Console.WriteLine($"The lower bound of game - { game.LowerBound }\nThe upper bound of game - { game.UpperBound }");
        }
    }
}
