using System;
using System.Collections.Generic;
using System.Linq;
using NewCardsFramework.Players;
using Newtonsoft.Json;
using ProtoBuf;

namespace NewCardsFramework.Poker
{
    /// <summary>
    /// 
    /// </summary>
    [ProtoContract]
    public class PokerTournament
    {
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(1)]
        public string PokerTournamentName;

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(2)]
        public Guid UniqueTournamentName;

        /// <summary>
        /// The Decimal amount that a play would buy in for
        /// </summary>
        [ProtoMember(3)]
        public decimal BuyIn;


        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(6)]
        public PokerTournamentStructure TournamentStructure;

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(5)]
        public List<PokerTournamentRegistration> RegistrationList;

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(8)]
        public int RebuyCount;
        
        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int TotalChipCount
        {
            get
            {
                var returnable = 0;
                foreach (var player in RegistrationList)
                {
                    if (player.PaidBuyIn) returnable += TournamentStructure.StartingStack;
                    if (player.HadRebuy && TournamentStructure.RebuyAllowed)
                    {
                        returnable += player.RebuyCount * TournamentStructure.RebuyStack;
                    }
                    if (player.HadAddOn && TournamentStructure.AddOnAllowed)
                    {
                        returnable += player.AddOnCount * TournamentStructure.AddonStack;
                    }
                }
                return returnable;
            }
        }

        /// <summary>
        /// The average chips per player
        /// </summary>
        public int AverageChipCount => Convert.ToInt32(Math.Ceiling((decimal)TotalChipCount / PlayerCount));

        /// <summary>
        /// The number of players
        /// </summary>
        public int PlayerCount => RegistrationList.Count;

        /// <summary>
        /// Property derived from the BuyIn, formatted to GBP
        /// </summary>
        public string FriendlyBuyIn => string.Format(new System.Globalization.CultureInfo("en-GB"), $"{BuyIn:C}");

        /// <summary>
        /// 
        /// </summary>
        public decimal TotalPrizePool => PlayerCount * BuyIn;

        /// <summary>
        /// 
        /// </summary>
        public bool AddOnAllowed => TournamentStructure.AddOnAllowed;
        /// <summary>
        /// 
        /// </summary>
        public bool RebuyAllowed => TournamentStructure.RebuyAllowed;
        #endregion

        /// <summary>
        /// Default Constructor for use in JsonDeserialization
        /// </summary>
        [JsonConstructor]
        public PokerTournament()
        {
            RegistrationList = new List<PokerTournamentRegistration>();
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="buyIn">The monetary amount that the Tournament will be played for</param>
        /// <param name="levels">A list of all the possible levels</param>
        /// <param name="allowRebuy">If rebuys are allowed or not</param>
        /// <param name="blindTimes"></param>
        /// <param name="rebuy"></param>
        /// <param name="numberOfRebuysAllowed"></param>
        public PokerTournament(decimal buyIn, List<BlindLevel> levels, bool allowRebuy,TimeSpan blindTimes, decimal rebuy = 0m,int numberOfRebuysAllowed = 0)
        {
            BuyIn = buyIn;
            TournamentStructure = new PokerTournamentStructure
            {
                BlindLevels = levels,
                BlindTimes = blindTimes,
                RebuyAllowed = allowRebuy
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="registeredPlayer"></param>
        public void AddPlayer(Player registeredPlayer)
        {
            if(RegistrationList.Any(x => x.Player == registeredPlayer && x.Active)) throw new PlayerAlreadyRegisteredException();
            var registration = new PokerTournamentRegistration(registeredPlayer);
            RegistrationList.Add(registration);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="knockedOutPlayer"></param>
        public void KnockPlayerOut(Player knockedOutPlayer)
        {
            var players = RegistrationList.Where(x => x.Player == knockedOutPlayer && x.Active).ToList();
            if (players.Count == 0) throw new PlayerNotFoundException();
            foreach (var player in players)
            {
                player.Active = false;
            }
        }
    }

    /// <summary>
    /// Exception is thrown when the player that is specified can't be found
    /// </summary>
    public class PlayerNotFoundException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        public override string Message { get; } = "Player Not Found";
    }
}
