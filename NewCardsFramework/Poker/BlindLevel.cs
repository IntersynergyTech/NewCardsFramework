using System;
using ProtoBuf;

namespace NewCardsFramework.Poker
{
    /// <summary>
    /// 
    /// </summary>
    [ProtoContract]
    public class BlindLevel : IComparable<BlindLevel>, IComparable
    {
        /// <summary>
        /// The small blind for this level
        /// </summary>
        [ProtoMember(1)]
        public int SmallBlind;
        /// <summary>
        /// The big blind for this level
        /// </summary>
        [ProtoMember(2)]
        public int BigBlind;
        /// <summary>
        /// The ante for this level
        /// </summary>
        [ProtoMember(3)]
        public int Ante;
        /// <summary>
        /// The Time this Level lasts for
        /// </summary>
        [ProtoMember(4)]
        public TimeSpan LevelTime;
        #region Properties
        /// <summary>
        /// A friendly way to describe the blind level
        /// </summary>
        public string BlindLevelText => Ante != 0 ? $"Blinds {SmallBlind}/{BigBlind} Ante{Ante}" : $"Blinds {SmallBlind}/{BigBlind}";

        /// <summary>
        /// 
        /// </summary>
        public string BlindLevelUI => $"{SmallBlind}/{BigBlind}/{Ante}";

        /// <summary>
        /// 
        /// </summary>
        public int SmallBlindUI
        {
            get => SmallBlind;
            set => SmallBlind = value;
        }
        /// <summary>
        /// 
        /// </summary>
        public int BigBlindUI => BigBlind;
        /// <summary>
        /// 
        /// </summary>
        public int AnteUI => Ante;
        #endregion

        #region Constructors
        /// <summary>
        /// 
        /// </summary>
        public BlindLevel()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="small"></param>
        /// <param name="big"></param>
        /// <param name="ante"></param>
        public BlindLevel(int small, int big, int ante) 
        {
            SmallBlind = small;
            BigBlind = big;
            Ante = ante;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(BlindLevel other)
        {
            return this.SmallBlind.CompareTo(other.SmallBlind);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            return this.SmallBlind.CompareTo(((BlindLevel)obj).SmallBlind);
        }
    }
}