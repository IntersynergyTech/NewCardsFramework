using NewCardsFramework.Players;
using ProtoBuf;

namespace NewCardsFramework.Poker
{
    /// <summary>
    /// Class which contains a Registration for a tournament
    /// </summary>
    [ProtoContract]
    public class PokerTournamentRegistration
    {
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(1)]
        public Player Player;
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(2)]
        public bool PaidBuyIn = true;
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(3)]
        public bool HadRebuy = false;
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(4)]
        public bool HadAddOn = false;
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(5)]
        public int RebuyCount = 0;
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(6)]
        public int AddOnCount = 0;
        /// <summary>
        /// 
        /// </summary>
        [ProtoMember(7)]
        public bool Active = true;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newPlayer"></param>
        public PokerTournamentRegistration(Player newPlayer)
        {
            Player = newPlayer;
            PaidBuyIn = true;
            Active = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public PokerTournamentRegistration()
        {
            
        }
    }
}