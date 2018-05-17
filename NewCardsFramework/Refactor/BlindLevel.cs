using System;
using System.Collections.Generic;
using System.Linq;

namespace NewCardsFramework.Refactor
{
    /// <summary>
    /// Blind Levels with a fixed Time Period, set in the constructor
    /// </summary>
    public class StaticBlindLevel : IBlindLevel
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

        /// <summary>
        /// 
        /// </summary>
        public TimeSpan BlindSpan { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public StaticBlindLevel()
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class StaticBlindStructure
    {
        /// <summary>
        /// 
        /// </summary>
        public string StructureName { get; }
        /// <summary>
        /// 
        /// </summary>
        public List<StaticBlindLevel> SortedBlindLevel { get; }

        /// <summary>
        /// 
        /// </summary>
        public Queue<StaticBlindLevel> QueuedBlinds { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blindLevels"></param>
        public StaticBlindStructure(IEnumerable<StaticBlindLevel> blindLevels, string name)
        {
            var staticBlindLevelsList = blindLevels.ToList();
            SortedBlindLevel = new List<StaticBlindLevel>(staticBlindLevelsList.OrderBy(x => x.SmallBlind));
            
            QueuedBlinds = new Queue<StaticBlindLevel>(staticBlindLevelsList.OrderBy(x => x.SmallBlind));
            StructureName = name;
        }
    }
}