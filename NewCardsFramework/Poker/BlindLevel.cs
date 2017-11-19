namespace NewCardsFramework.Poker
{
    /// <summary>
    /// 
    /// </summary>
    public class BlindLevel
    {
        /// <summary>
        /// The small blind for this level
        /// </summary>
        public int SmallBlind;
        /// <summary>
        /// The big blind for this level
        /// </summary>
        public int BigBlind;
        /// <summary>
        /// The ante for this level
        /// </summary>
        public int Ante;
        /// <summary>
        /// A friendly way to describe the blind level
        /// </summary>
        public string BlindLevelText => Ante != 0 ? $"Blinds {SmallBlind}/{BigBlind} Ante{Ante}" : $"Blinds {SmallBlind}/{BigBlind}";
    }
}