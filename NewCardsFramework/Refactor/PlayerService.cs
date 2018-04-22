using System.Collections;
using System.Collections.Generic;

namespace NewCardsFramework.Refactor
{
    /// <summary>
    /// The basic service for all players
    /// </summary>
    public interface IPlayerService
    {
        /// <summary>
        /// Registers the specified player in the database
        /// </summary>
        /// <param name="playerToRegister"></param>
        void AddNewPlayer(IPlayer playerToRegister);
        /// <summary>
        /// Gets all non archived Players in the database
        /// </summary>
        /// <returns></returns>
        IEnumerable<IPlayer> GetAllPlayers();
        
        /// <summary>
        /// Updates a specified Player record
        /// </summary>
        /// <param name="playerToUpdate"></param>
        void UpdateRecord(IPlayer playerToUpdate);
        
        /// <summary>
        /// Archives a specified player from the database
        /// </summary>
        /// <param name="playerToDelete"></param>
        void DeletePlayer(IPlayer playerToDelete);
    }

    /// <summary>
    /// The Service used for SQLite Databases
    /// </summary>
    public class PlayerSqliteService : IPlayerService
    {
        public PlayerSqliteService()
        {
            
        }
        public void AddNewPlayer(IPlayer playerToRegister)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<IPlayer> GetAllPlayers()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateRecord(IPlayer playerToUpdate)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePlayer(IPlayer playerToDelete)
        {
            throw new System.NotImplementedException();
        }
    }
}