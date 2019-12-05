using System.Linq;

namespace RockPaperScissors
{
    public static class Validator
    {
        static private readonly string[] strategies = { Constants.ROCK, Constants.PAPER, Constants.SCISSORS };

        public static void ValidateNumberPlayers(string[][] play)
        {
            if (play.Length != Constants.NUMBER_PLAYERS)
                throw new WrongNumberOfPlayersError("Number of players must be 2.");
        }

        public static void ValidateStrategy(string strategy)
        {
            if (!strategies.ToList().Contains(strategy))
                throw new NoSuchStrategyError("Strategy must be R or P or S.");
        }
    }
}