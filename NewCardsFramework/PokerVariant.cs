namespace NewCardsFramework
{
    /// <summary>
    /// 
    /// </summary>
    public enum PokerVariant
    {
        /// <summary>
        /// Standard No Limit Texas Hold'em
        /// </summary>
        NoLimitTexasHoldem = 1,
        /// <summary>
        /// Omaha with the max bet size limited by the size of the Pot
        /// </summary>
        PotLimitOmaha = 2,
        /// <summary>
        /// Limit Seven Card Stud
        /// </summary>
        SevenCardStud = 3,
        /// <summary>
        /// Limit Seven Card Stud Low Only
        /// </summary>
        Razz = 4,
        /// <summary>
        /// No Limit 5 Card Draw
        /// </summary>
        FiveCardDraw = 5,
        /// <summary>
        /// A variant of PLO where the pot is split between the high and low hands
        /// </summary>
        OmahaHiLo = 6,
        /// <summary>
        /// 2-7 Triple Draw
        /// </summary>
        TripleDraw = 7,
    }
}