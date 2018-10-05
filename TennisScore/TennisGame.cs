using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class TennisGame
    {
        private readonly IRepository<Game> _repo;

        private Dictionary<int, string> _scoreLookup = new Dictionary<int , string>{{1, "Fifteen"} ,{2, "Thirty"}
        };

        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
        }

        public string ScoreResult(int gameId)
        {
            var game = this._repo.GetGame(gameId);
            if (game.FirstPlayerScore > 0)
            {
                return _scoreLookup[game.FirstPlayerScore] + " Love";
            }

            if (game.FirstPlayerScore == 2)
            {
                return "Thirty Love";
            }

            if (game.FirstPlayerScore == 1)
            {
                return "Fifteen Love";
            }

            return "Love All";
        }
    }
}