using System;

namespace RockPaperScissors
{
    static class Program
    {
        private const string INPUT_PLAY = "[[\"Armando\",\"P\"],[\"Dave\",\"S\"]]";
        private const string INPUT_TOURNAMENT = "[[[[\"Armando\",\"P\"],[\"Dave\",\"S\"]],[[\"Richard\",\"R\"],[\"Michael\",\"S\"]],],[[[\"Allen\",\"S\"],[\"Omer\",\"P\"]],[[\"David E.\",\"R\"],[\"Richard X.\",\"P\"]]]]";

        static void Main(string[] args)
        {
            try
            {
                var game = new Game();

                var winner = game.RpsGameWinner(Converter.ToTwoArrayString(INPUT_PLAY));
                Console.WriteLine($"Part A: {Converter.ToString(winner)}");

                winner = game.RpsTournamentWinner(Converter.ToFourArrayString(INPUT_TOURNAMENT));
                Console.WriteLine($"Part B: {Converter.ToString(winner)}");
            }
            catch (Exception e) when (e is WrongNumberOfPlayersError || e is NoSuchStrategyError)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}