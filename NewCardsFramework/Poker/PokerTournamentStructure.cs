using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using ProtoBuf;

namespace NewCardsFramework.Poker
{
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
        /// The number of chips a player starts with
        /// </summary>
        [ProtoMember(5)]
        public int StartingStack;

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(6)]
        public bool RebuyAllowed;
        
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(7)]
        public int RebuyStack;

        public int NumberOfRebuysAllowed;

        public bool AddOnAllowed;
        public int AddonStack;
        

        /// <summary>
        /// 
        /// </summary>
        public PokerTournamentStructure()
        {
            
        }
    }
}