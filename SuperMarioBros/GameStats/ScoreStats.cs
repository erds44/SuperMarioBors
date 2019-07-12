using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;
using static SuperMarioBros.Utility.GeneralConstants;

namespace SuperMarioBros.Stats
{
    public class ScoreStats
    {
        public int CurrentScore {get;private set;}
        public ScoreStats()
        {
            CurrentScore = InitialCount;
        }
        public void CollectCoinSocre(Vector2 position)
        {
            CurrentScore += CoinScore;
            ObjectFactory.Instance.CreateScoreText(position, "200");
        }
        public void CollectEnemyKilledScore(Vector2 position, int baseScore, int killStreak)
        {
            int killScore = baseScore * killStreak;
            CurrentScore += killScore;
            ObjectFactory.Instance.CreateScoreText(position, killScore.ToString());
        }

        public void CollectFlagPoleScore(Vector2 position)
        {  
            int flagScore = (int)((FlagScoreBase - position.Y) * FlagScoreScale);
            CurrentScore += flagScore;
            ObjectFactory.Instance.CreateScoreText(position, flagScore.ToString());
        }

        public void CollectPowerUp(Vector2 position)
        {
            CurrentScore += PowerUpScore;
            ObjectFactory.Instance.CreateScoreText(position, "1000");
        }
        public void AddRemainingTimeScore(int score)
        {
            CurrentScore += score;
        }
        public void Reset()
        {
            CurrentScore = InitialCount;
        }
       
    }
}
