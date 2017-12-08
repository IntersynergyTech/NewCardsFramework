using System;

namespace NewCardsFramework.Poker
{
    /// <summary>
    /// /
    /// </summary>
    public class PlayerAlreadyRegisteredException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public override string Message { get; } = "This player is already registered";
    }
}