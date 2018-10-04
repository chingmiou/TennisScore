using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace TennisScore
{
    [TestClass]
    public class UnitTest1
    {
      private   IRepository<Game> _repository = Substitute.For<IRepository<Game>>();
        private TennisGame _tennisGame;
        private const int AnyGameId = 1;
        private string FirstPlayerName = "Alex";
        private string SecondPlayerName = "Sam";

        [TestInitialize]
        public void TestInit()
        {
            _tennisGame = new TennisGame(_repository);
        }
        [TestMethod]
        public void Love_All()
        {
            GivenGame(0, 0);
            ScoreResultShouldBe("Love All");
        }
        [TestMethod]
        public void Fifteen_Love()
        {
            GivenGame(1, 0);
            ScoreResultShouldBe("Fifteen Love");
        }
        
        [TestMethod]
        public void Thirty_Love()
        {
            GivenGame(2, 0);
            ScoreResultShouldBe("Thirty Love");
        }
        [TestMethod]
        public void Forty_Love()
        {
            GivenGame(3, 0);
            ScoreResultShouldBe("Forty Love");
        }
        [TestMethod]
        public void Love_Fifteen()
        {
            GivenGame(0, 1);
            ScoreResultShouldBe("Love Fifteen");
        }
        [TestMethod]
        public void Love_Thirty()
        {
            GivenGame(0, 2);
            ScoreResultShouldBe("Love Thirty");
        }
        [TestMethod]
        public void Fifteen_All()
        {
            GivenGame(1, 1);
            ScoreResultShouldBe("Fifteen All");
        }
        [TestMethod]
        public void Thirty_All()
        {
            GivenGame(2, 2);
            ScoreResultShouldBe("Thirty All");
        }

        [TestMethod]
        public void Deuce()
        {
            GivenGame(3, 3);
            ScoreResultShouldBe("Deuce");
        }


        [TestMethod]
        public void FirstPlayer_Adv()
        {
            GivenGame(4, 3);
            ScoreResultShouldBe($"{FirstPlayerName} Adv");
        }

        [TestMethod]
        public void SecondPlayer_Adv()
        {
            GivenGame(3, 4);
            ScoreResultShouldBe($"{SecondPlayerName} Adv");
        }

        private void ScoreResultShouldBe(string expected)
        {
            var scoreResult = _tennisGame.ScoreResult(AnyGameId);
            Assert.AreEqual(expected, scoreResult);
        }

        private void GivenGame(int firstPlayerScore, int secondPlayerScore)
        {
            _repository.GetGame(AnyGameId).Returns(returnThis: new Game
            {
                Id = AnyGameId, FirstPlayerScore = firstPlayerScore,
                SecondPlayerScore = secondPlayerScore,
                FirstPlayerName = FirstPlayerName,
                SecondPlayerName = SecondPlayerName
            });
        }
    }
}