using Microsoft.Xna.Framework;
using SuperMarioBros.Objects;
using SuperMarioBros.Utility;
using static SuperMarioBros.Utility.GeneralConstants;

namespace SuperMarioBros.Stats
{
    public class LifeStats
    {
        private int totalLives;
        public int RemaningLives { get; private set; }
        public LifeStats()
        {
            totalLives = InitialLife;
            RemaningLives = totalLives;
        }
        public void GainExtraLife(Vector2 position)
        {
            RemaningLives++;
            ObjectFactory.Instance.CreateScoreText(position, StringConsts.LF1);
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
