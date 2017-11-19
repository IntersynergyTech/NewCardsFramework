using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NewCardsFramework.Players
{
    /// <summary>
    /// 
    /// </summary>
    public class BoardHistory
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid BoardHistoryUniqueId;
        /// <summary>
        /// Time at which the Board was updated
        /// </summary>
        public DateTime RecordedTime;
        /// <summary>
        /// Dictionary containing the Player and their position at the time
        /// </summary>
        public Dictionary<Player, decimal> BoardPosition;

        /// <summary>
        /// 
        /// </summary>
        [JsonConstructor]
        public BoardHistory()
        {
            
        }
    }
}
