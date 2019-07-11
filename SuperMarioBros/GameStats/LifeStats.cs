using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Stats
{
    public class LifeStats
    {
        private int totalLives;
        public int RemaningLives { get; private set; }
        public LifeStats()
        {
            totalLives = 3;
            RemaningLives = totalLives;
        }
        public void GainExtraLife(Vector2 position)
        {
            RemaningLives++;
            ObjectFactory.Instance.CreateScoreText(position, "1LF");
        }
        public void LoseLife()
        {
            RemaningLives--;
        }     
        public void Reset()
        {
            RemaningLives = totalLives;
        }
    }
}
