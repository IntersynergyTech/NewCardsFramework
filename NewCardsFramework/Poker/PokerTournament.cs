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
        /// Returns a formatted string based on the number of rebuys allowed
        /// </summary>
        public string FriendlyRebuy
        {
            get
            {
                if (Rebuy != 0m && NumberOfRebuysAllowed != 0)
                {
                    return string.Format(new System.Globalization.CultureInfo("en-GB"), $"{Rebuy:C}");
                }
                else return "Rebuys not Permitted";
            }
        }
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(6)]
        public PokerTournamentStructure TournamentStructure;

        [ProtoMember(5)]
        public List<PokerTournamentRegistration> RegistrationList;

        
        public int RebuyCount;


        #region Properties
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

        public decimal TotalPrizePool => PlayerCount * BuyIn;

        public bool AddOnAllowed => TournamentStructure.AddOnAllowed;
        public bool RebuyAllowed => TournamentStructure.RebuyAllowed;
        #endregion

        /// <summary>
        /// Default Constructor for use in JsonDeserialization
        /// </summary>
        [JsonConstructor]
        public PokerTournament()
        {
            
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
            if (allowRebuy)
            {
                NumberOfRebuysAllowed = numberOfRebuysAllowed;
                Rebuy = rebuy;
                
            }
        }

        public void AddPlayer(Player registeredPlayer)
        {
            if(RegistrationList.Any(x => x.Player == registeredPlayer && x.Active)) throw new PlayerAlreadyRegisteredException();
            var registration = new PokerTournamentRegistration(registeredPlayer);
        }

        public void KnockPlayerOut(Player knockedOutPlayer)
        {
            foreach (var player in RegistrationList.Where(x => x.Player == knockedOutPlayer))
            {
                player.Active = false;
            }
        }
    }

    [ProtoContract]
    public class PokerTournamentRegistration
    {
        [ProtoMember(1)]
        public Player Player;
        [ProtoMember(2)]
        public bool PaidBuyIn = true;
        [ProtoMember(3)]
        public bool HadRebuy = false;
        [ProtoMember(4)]
        public bool HadAddOn = false;
        [ProtoMember(5)]
        public int RebuyCount = 0;
        [ProtoMember(6)]
        public int AddOnCount = 0;
        [ProtoMember(7)]
        public bool Active = true;

        public PokerTournamentRegistration(Player newPlayer)
        {
            Player = newPlayer;
            PaidBuyIn = true;
            Active = true;
        }

        public PokerTournamentRegistration()
        {
            
        }
    }

    public class PlayerAlreadyRegisteredException : Exception
    {
        
    }
}
