using BowlingBall;

namespace DriverProgram
{
    internal class Program
    {
        private static IGame game;
        static void Main(string[] args)
        {
            game = new PlaneGame();
            RollMany(20, 1);
            Console.WriteLine(game.GetScore()); // 20

            game = new Game();
            RollMany(12, 10);
            Console.WriteLine(game.GetScore()); // 300

            game = new PlaneGame();
            RollSpare();
            game.Roll(3);
            game.Roll(3);
            RollStrike();
            RollMany(12, 3);
            RollStrike();
            game.Roll(4);
            game.Roll(4);
            Console.WriteLine(game.GetScore()); // 89

            game = new PGame();
            RollSpare();
            game.Roll(3);
            game.Roll(3);
            RollStrike();
            RollMany(14, 3);
            Console.WriteLine(game.GetScore()); // 77

            game = new BowlingGame();
            RollSpare();
            game.Roll(3);
            game.Roll(3);
            RollStrike();
            RollMany(14, 3);
            Console.WriteLine(game.GetScore()); // 77

            // random input
            game = new Game();
            RollMany(new int[] { 1, 3, 7, 3, 10, 1, 7, 5, 2, 5, 3, 8, 2, 8, 2, 10, 9, 0 });
            Console.WriteLine(game.GetScore()); // 131

            Console.ReadKey();
        }

        private static void RollStrike()
        {
            game.Roll(10);
        }

        private static void RollSpare()
        {
            game.Roll(5);
            game.Roll(5);
        }

        private static void RollMany(int times, int pins)
        {
            for (int i = 0; i < times; i++)
            {
                game.Roll(pins);
            }
        }

        private static void RollMany(int[] pins)
        {
            for (int i = 0; i < pins.Length; i++)
            {
                game.Roll(pins[i]);
            }
        }
    }
}