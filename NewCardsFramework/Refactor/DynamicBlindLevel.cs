namespace NewCardsFramework.Refactor
{
    /// <summary>
    /// 
    /// </summary>
    public class DynamicBlindLevel : IBlindLevel
    {
        /// <summary>
        /// 
        /// </summary>
        public decimal SmallBlind { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal BigBlind { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal Ante { get; set; }
    }
}