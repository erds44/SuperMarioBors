using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Stats
{
    public class ScoreStats
    {
        public int currentScore {get;private set;}
        public ScoreStats()
        {
            currentScore = 0;
        }
        public void CollectCoinSocre(Vector2 position)
        {
            currentScore += 200;
            ObjectFactory.Instance.CreateScoreText(position, "200");
        }
        public void CollectEnemyKilledScore(Vector2 position, int baseScore, int killStreak)
        {
            int killScore = baseScore * killStreak;
            currentScore += killScore;
            ObjectFactory.Instance.CreateScoreText(position, killScore.ToString());
        }

        public void CollectFlagPoleScore(Vector2 position)
        {  
            int flagScore = (int)(375 - position.Y) * (5000 / 304);
            currentScore += flagScore;
            ObjectFactory.Instance.CreateScoreText(position, flagScore.ToString());
        }

        public void CollectPowerUp(Vector2 position)
        {
            currentScore += 1000;
            ObjectFactory.Instance.CreateScoreText(position, "1000");
        }
        public void AddRemainingTimeScore(int score)
        {
            currentScore += score;
        }
        public void Reset()
        {
            currentScore = 0;
        }
       
    }
}
