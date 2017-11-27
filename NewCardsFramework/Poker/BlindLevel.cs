using ProtoBuf;

namespace NewCardsFramework.Poker
{
    /// <summary>
    /// 
    /// </summary>
    [ProtoContract]
    public class BlindLevel
    {
        /// <summary>
        /// The small blind for this level
        /// </summary>
        [ProtoMember(1)]
        public int SmallBlind;
        /// <summary>
        /// 
        /// </summary>
        public int SmallBlindUI => SmallBlind;
        /// <summary>
        /// 
        /// </summary>
        public int BigBlindUI => BigBlind;
        /// <summary>
        /// 
        /// </summary>
        public int AnteUI => Ante;

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
        /// A friendly way to describe the blind level
        /// </summary>
        public string BlindLevelText => Ante != 0 ? $"Blinds {SmallBlind}/{BigBlind} Ante{Ante}" : $"Blinds {SmallBlind}/{BigBlind}";

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
    }
}