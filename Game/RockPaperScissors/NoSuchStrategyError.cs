using System;

namespace RockPaperScissors
{
    public class NoSuchStrategyError : Exception
    {
        public NoSuchStrategyError() : base()
        {

        }

        public NoSuchStrategyError(string message) : base(message)
        {

        }
    }
}