using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NewCardsFramework.Players;
using NewCardsFramework.Poker;

namespace CardsFramework.Tests
{
    [TestClass]
    public class PokerTournamentTests
    {
        [TestMethod]
        public void KnockoutTest()
        {
            var tournament = new PokerTournament();
            var player = new Player
            {
                CurrentPosition = 0,
                FirstName = "Owen",
                PlayerId = 0,
                Surname = "Hamer"
            };
            tournament.AddPlayer(player);
            tournament.KnockPlayerOut(player);
            Assert.IsFalse(tournament.RegistrationList.Any(x => x.Player == player && x.Active));
        }
        [TestMethod]
        [ExpectedException(typeof(PlayerNotFoundException))]
        public void KnockoutInvalidPlayer()
        {
            var tournament = new PokerTournament();
            tournament.KnockPlayerOut(new Player());
        }
        [TestMethod]
        public void AddPlayerTest()
        {
            var tournament = new PokerTournament();
            var player = new Player
            {
                CurrentPosition = 0,
                FirstName = "Owen",
                PlayerId = 0,
                Surname = "Hamer"
            };
            tournament.AddPlayer(player);
            var reg = new PokerTournamentRegistration(player);
            Assert.IsTrue(tournament.RegistrationList.Any(x => x.Player == reg.Player));
        }
        
        [TestMethod]
        [ExpectedException(typeof(PlayerAlreadyRegisteredException))]
        public void AddPlayerStillActive()
        {
            var tournament = new PokerTournament();
            var player = new Player
            {
                CurrentPosition = 0,
                FirstName = "Owen",
                PlayerId = 0,
                Surname = "Hamer"
            };
            tournament.AddPlayer(player);
            tournament.AddPlayer(player);
        }
        [TestMethod]
        public void StartingStackTest()
        {
            var expectedStack = 20000;
            var tournament = new PokerTournament();
            var structure = new PokerTournamentStructure
            {
                StartingStack = 10000
            };
            tournament.TournamentStructure = structure;
            var player1 = new Player();
            var player2 = new Player();

            tournament.AddPlayer(player1);
            tournament.AddPlayer(player2);
            Assert.AreEqual(tournament.TotalChipCount,expectedStack);
        }
        
    }
}
