namespace RockPaperScissors
{
    public class Game
    {
        public string[] RpsGameWinner(string[][] play) => Winner(play);

        public string[] RpsTournamentWinner(string[][][][] tournament) => Winner(tournament);

        private string[] Winner(dynamic game)
        {
            var play = game as string[][];

            if (play == null)
                return Winner(new string[][] { Winner(game[0]), Winner(game[1]) });

            Validator.ValidateNumberPlayers(play);

            var namePlayerOne = play[0][0];
            var strategyPlayerOne = play[0][1].ToUpper();
            var namePlayerTwo = play[1][0];
            var strategyPlayerTwo = play[1][1].ToUpper();

            Validator.ValidateStrategy(strategyPlayerOne);
            Validator.ValidateStrategy(strategyPlayerTwo);

            if (strategyPlayerOne == strategyPlayerTwo)
                return Converter.ToArrayString(namePlayerOne, strategyPlayerOne);

            if (strategyPlayerOne == Constants.ROCK)
            {
                if (strategyPlayerTwo == Constants.SCISSORS)
                    return Converter.ToArrayString(namePlayerOne, strategyPlayerOne);

                return Converter.ToArrayString(namePlayerTwo, strategyPlayerTwo);
            }

            if (strategyPlayerOne == Constants.PAPER)
            {
                if (strategyPlayerTwo == Constants.ROCK)
                    return Converter.ToArrayString(namePlayerOne, strategyPlayerOne);

                return Converter.ToArrayString(namePlayerTwo, strategyPlayerTwo);
            }

            if (strategyPlayerTwo == Constants.PAPER)
                return Converter.ToArrayString(namePlayerOne, strategyPlayerOne);

            return Converter.ToArrayString(namePlayerTwo, strategyPlayerTwo);
        }
    }
}