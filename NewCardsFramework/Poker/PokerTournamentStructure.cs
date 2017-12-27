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

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(8)]
        public int NumberOfRebuysAllowed;

        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(9)]
        public bool AddOnAllowed;
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(11)]
        public int AddonStack;
        

        /// <summary>
        /// 
        /// </summary>
        public PokerTournamentStructure()
        {
            
        }

        public BlindLevel GetNextLevel(BlindLevel currentLevel)
        {
            var index = BlindLevels.IndexOf(currentLevel);
            return index + 1 > BlindLevels.Count ? currentLevel : BlindLevels[index + 1];
        }
    }
}