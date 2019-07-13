using Microsoft.Xna.Framework;
using System;

namespace SuperMarioBros.Stats
{
    public class StatsManager
    {
        private CoinStats coinStats;
        private LifeStats lifeStats;
        private TimeStats timeStats;
        private ScoreStats scoreStats;

        public event Action timeUpEvent;
        public int Coin { get => coinStats.CurrentCoin; }
        public int Time { get => (int)timeStats.currentTime; }
        public int Life { get => lifeStats.RemaningLives; }
        public int Score { get => scoreStats.CurrentScore; }

        public static StatsManager Instance { get; } = new StatsManager();
        public void Initialize()
        {
            coinStats = new CoinStats();
            lifeStats = new LifeStats();
            timeStats = new TimeStats();
            scoreStats = new ScoreStats();
        }

        public void CoinCollected(Vector2 position)
        {
            coinStats.CoinCollected();
            scoreStats.CollectCoinSocre(position);
        }

        public void Enemykilled(Vector2 position, int baseScore) // i.e. block kill enemy
        {
            Enemykilled(position, baseScore, Utility.GeneralConstants.InitialKillStreak);
        }
        public void Enemykilled(Vector2 position, int baseScore, int killStreak) // i.e. block kill enemy
        {
            scoreStats.CollectEnemyKilledScore(position, baseScore, killStreak);
        }

        public void CollectFlagPopleScore(Vector2 position)
        {
            scoreStats.CollectFlagPoleScore(position);
        }
        public void GainExtraLife(Vector2 position)
        {
            lifeStats.GainExtraLife(position);
        }

        public void CollectPowerUp(Vector2 position)
        {
            scoreStats.CollectPowerUp(position);
        }
        public void Reset()
        {
            coinStats.Reset();
            lifeStats.Reset();
            scoreStats.Reset();
            timeStats.Reset();
        }

        public void Update(GameTime gameTime)
        {
            timeStats.Update(gameTime);
            if (Time <= 0) timeUpEvent?.Invoke();
        }

        public void LoseLife()
        {
            lifeStats.LoseLife();
        }
        public void ResetTimer()
        {
            timeStats.Reset();
        }
        public void CollectRemainingTime()
        {
            scoreStats.AddRemainingTimeScore(timeStats.TimeBonusScore());
        }
    }
}
