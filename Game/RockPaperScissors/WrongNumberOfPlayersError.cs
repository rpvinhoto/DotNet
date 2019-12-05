using System;

namespace RockPaperScissors
{
    public class WrongNumberOfPlayersError : Exception
    {
        public WrongNumberOfPlayersError() : base()
        {

        }

        public WrongNumberOfPlayersError(string message) : base(message)
        {

        }
    }
}