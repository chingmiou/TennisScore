using System;

namespace TennisScore
{
    public class Game
    {
        public int SecondPlayerScore { get; set; }
        public int FirstPlayerScore { get; set; }
        public int Id { get; set; }
        public string FirstPlayerName { get; set; }
        public string SecondPlayerName { get; set; }

        public bool IsScoreDifferent()
        {
            return FirstPlayerScore != SecondPlayerScore;
        }

        public bool IsDeuce()
        {
            var sameScore = this.FirstPlayerScore == this.SecondPlayerScore;
            return (this.FirstPlayerScore >= 3) && sameScore;
        }

        public bool IsAdv()
        {
            return Math.Abs(FirstPlayerScore - SecondPlayerScore) == 1;
        }

        public string AdvPlayer()
        {
            var advPlayer = FirstPlayerScore > SecondPlayerScore
                ? FirstPlayerName
                : SecondPlayerName;
            return advPlayer;
        }
    }
}