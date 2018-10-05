using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TennisScore
{
    [TestClass]
    public class TennisGameTests
    {
        private const int AnyGameId = 1;
        private IRepository<Game> _repository = Substitute.For<IRepository<Game>>();
        private TennisGame _tennisGame;

        [TestMethod]
        public void Love_All()
        {
            GivenGame(firstPlayerScore: 0, secondPlayerScore: 0);
            ScoreResultShouldBe("Love All");
        }

        private void ScoreResultShouldBe(string expected)
        {
            var scoreResult = _tennisGame.ScoreResult(AnyGameId);
            Assert.AreEqual(expected, scoreResult);
        }

        private void GivenGame(int firstPlayerScore, int secondPlayerScore)
        {
            _repository.GetGame(AnyGameId).Returns(new Game {Id = AnyGameId, FirstPlayerScore = firstPlayerScore, SecondPlayerScore =secondPlayerScore });
        }

        [TestInitialize]
        public void TestInit()
        {
            _tennisGame = new TennisGame(_repository);
        }
    }
}