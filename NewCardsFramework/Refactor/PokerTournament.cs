using System;
using System.Collections.Generic;
using System.Linq;

namespace NewCardsFramework.Refactor
{
    /// The basic class for a Poker Tournament
    /// <inheritdoc />
    public class PokerTournament :ITournament
    {
        /// <summary>
        /// 
        /// </summary>
        public PokerTournament(decimal entryFee, IBlindLevelCollection blinds, IPlayerService service, IGame gameType)
        {
            TournamentTypeValue = TournamentType.Poker;
            CurrentEntry = entryFee;
            Blinds = blinds;
            CurrentGameType = gameType;
        }
        /// <summary>
        /// The current TournamentName
        /// </summary>
        public string TournamentName { get; set; }

        /// <summary>
        /// The Type of Tournament
        /// </summary>
        public TournamentType TournamentTypeValue { get; }
        
        /// <summary>
        /// All players currently registered to this tournament
        /// </summary>
        public List<IRegistration> Players { get; set; }
        
        /// <summary>
        /// The cost of entry to this tournament
        /// </summary>
        public decimal CurrentEntry { get; set; }
        
        /// <summary>
        /// The Blinds in this game
        /// </summary>
        public IBlindLevelCollection Blinds { get; set; }
        public IGame CurrentGameType { get; }
        public void RegisterPlayer(IPlayer registeredPlayer)
        {
            throw new NotImplementedException();
        }

        public void KnockoutPlayer(IPlayer currentPlayer)
        {
            
        }

        /// <summary>
        /// Gets a list of the current players who are active
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<IPlayer> GetCurrentPlayers()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Checks if a specified player is active in the current tournament
        /// </summary>
        /// <param name="playerToCheck">The player which should be searched for</param>
        /// <returns>True if the player is present and active, false otherwise.</returns>
        public bool PlayerIsRegistered(IPlayer playerToCheck)
        {
            return Players.Any(x => x.RegPlayerId == playerToCheck.PlayerId && x.Active);
        }
    }
}