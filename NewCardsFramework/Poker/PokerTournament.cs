using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
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
        /// Property derived from the BuyIn, formatted to GBP
        /// </summary>
        public string FriendlyBuyIn => string.Format(new System.Globalization.CultureInfo("en-GB"), $"{BuyIn:C}");

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(4)]
        public decimal Rebuy;
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(5)]
        public int NumberOfRebuysAllowed;
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
    }

    /// <summary>
    /// 
    /// </summary>
    [ProtoContract]
    public class PokerTournamentStructure
    {

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(1)]
        public string StructureName;

        /// <summary>
        /// 
        /// </summary>
        public Guid StructureId
        {
            get
            {
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    return new Guid(md5.ComputeHash(Encoding.UTF8.GetBytes(StructureName)));
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(2)]
        public TimeSpan BlindTimes;

        /// <summary>
        /// A list of all the BlindLevels
        /// </summary>
        [ProtoMember(3)]
        public List<BlindLevel> BlindLevels;

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(4)]
        public bool RebuyAllowed;

        /// <summary>
        /// 
        /// </summary>
        public PokerTournamentStructure()
        {
            
        }
    }
}
