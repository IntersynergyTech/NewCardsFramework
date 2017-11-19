using System;

namespace NewCardsFramework.Players
{
    /// <summary>
    /// Class for that handles player interaction
    /// </summary>
    public class Player
    {
        /// <summary>
        /// The Player's Numeric ID;
        /// </summary>
        public uint PlayerId;
        /// <summary>
        /// The player's first Name
        /// </summary>
        public string FirstName;
        /// <summary>
        /// The player's Surname
        /// </summary>
        public string Surname;
        /// <summary>
        /// Combines the first name and surname together
        /// </summary>
        public string FullName => $"{FirstName} {Surname}";

        /// <summary>
        /// 
        /// </summary>
        public decimal CurrentPosition;
    }
}
