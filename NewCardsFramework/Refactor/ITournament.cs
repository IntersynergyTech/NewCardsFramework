// ReSharper disable UnusedMember.Global

using System.Collections.Generic;
using System.ComponentModel.Design;

namespace NewCardsFramework.Refactor
{
#pragma warning disable 1591
    /// <summary>
    /// 
    /// </summary>
    public interface ITournament
    {
        string TournamentName { get; set; }
        TournamentType TournamentTypeValue { get; }
        List<IRegistration> Players { get; set; }
        decimal CurrentEntry { get; set; }
        IBlindLevelCollection Blinds { get; set; }
        IGame CurrentGameType { get; }
        void RegisterPlayer(IPlayer registeredPlayer);
        void KnockoutPlayer(IPlayer currentPlayer);
        IEnumerable<IPlayer> GetCurrentPlayers();
        bool PlayerIsRegistered(IPlayer playerToCheck);
    }

    public enum TournamentType
    {
        Unused = -1,
        Poker = 1,
        Cards = 2,
        Misc = 3
    }

    /// <summary>
    /// Contains default data for a player
    /// </summary>
    public interface IPlayer
    {
        int PlayerId { get; set; }
        string FirstName { get; set; }
        string Surname { get; set; }
        string FullName { get; }
        decimal CurrentPosition { get; set; }
        void UpdatePosition();
    }

    public interface IRegistration
    {
        int RegPlayerId { get; set; }
        bool Active { get; set; }
    }
    
    public interface IGame
    {
        string Name { get; set; }
        int MinPlayers { get; set; }
        int MaxPlayers { get; set; }
    }

    public interface IBlindLevelCollection : IEnumerable<IBlindLevel>
    {
        bool HasBlinds { get; set; }
        
    }

    public interface IBlindLevel
    {
        decimal SmallBlind { get; set; }
        decimal BigBlind { get; set; }
        decimal Ante { get; set; }
    }

#pragma warning restore 1591
}