using System;
using System.Collections.Generic;

namespace TennisScore
{
    public class TennisGame
    {
        private readonly IRepository<Game> _repo;

        private Dictionary<int, string> _scopeLookup = new Dictionary<int, string>
        {
            { 0, "Love"},
            { 1, "Fifteen"},
            { 2, "Thirty"},
            { 3, "Forty"},
        };

        public TennisGame(IRepository<Game> repo)
        {
            _repo = repo;
        }

        public string ScoreResult(int gameId)
        {
            var game = this._repo.GetGame(gameId);

            if (game.IsScoreDifferent())
            {
                if (IsReadyToWin(game))
                {
                    if (game.IsAdv())
                    {
                        var advPlayer = AdvPlayer(game);

                        return $"{advPlayer} Adv";
                    }
                }

                return _scopeLookup[game.FirstPlayerScore] + " " + _scopeLookup[game.SecondPlayerScore];
            }

            if (game.IsDeuce())
                return "Deuce";

            return _scopeLookup[game.FirstPlayerScore] + " All";
        }

        private static bool IsReadyToWin(Game game)
        {
            return game.FirstPlayerScore > 3 || game.SecondPlayerScore > 3;
        }

        private static string AdvPlayer(Game game)
        {
            var advPlayer = game.FirstPlayerScore > game.SecondPlayerScore
                ? game.FirstPlayerName
                : game.SecondPlayerName;
            return advPlayer;
        }
    }
}