﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [TestMethod]
        public void Fifteen_Love()
        {
            GivenGame(firstPlayerScore: 1, secondPlayerScore: 0);
            ScoreResultShouldBe("Fifteen Love");
        }

        [TestMethod]
        public void Thirty_Love()
        {
            GivenGame(firstPlayerScore: 2, secondPlayerScore: 0);
            ScoreResultShouldBe("Thirty Love");
        }

        [TestMethod]
        public void Forty_Love()
        {
            GivenGame(firstPlayerScore: 3, secondPlayerScore: 0);
            ScoreResultShouldBe("Forty Love");
        }

        [TestMethod]
        public void Love_Fifteen()
        {
            GivenGame(firstPlayerScore: 0, secondPlayerScore: 1);
            ScoreResultShouldBe("Love Fifteen");
        }

        [TestMethod]
        public void Love_Thirty()
        {
            GivenGame(firstPlayerScore: 0, secondPlayerScore: 2);
            ScoreResultShouldBe("Love Thirty");
        }
        [TestMethod]
        public void Fifteen_All()
        {
            GivenGame(firstPlayerScore: 1, secondPlayerScore: 1);
            ScoreResultShouldBe("Fifteen All");
        }

        private void ScoreResultShouldBe(string expected)
        {
            var scoreResult = _tennisGame.ScoreResult(AnyGameId);
            Assert.AreEqual(expected, scoreResult);
        }

        private void GivenGame(int firstPlayerScore, int secondPlayerScore)
        {
            _repository.GetGame(AnyGameId).Returns(new Game { Id = AnyGameId, FirstPlayerScore = firstPlayerScore, SecondPlayerScore = secondPlayerScore });
        }

        [TestInitialize]
        public void TestInit()
        {
            _tennisGame = new TennisGame(_repository);
        }
    }
}