using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NewCardsFramework.Players
{
    /// <summary>
    /// Handles the Board Positions
    /// </summary>
    public class CurrentBoard
    {
        /// <summary>
        /// Provides the history of the board
        /// </summary>
        public List<BoardHistory> History;
        /// <summary>
        /// The Current Position of the board
        /// </summary>
        public Dictionary<Player, decimal> CurrentPositions => History.OrderBy(x => x.RecordedTime).First().BoardPosition;
    }
}
