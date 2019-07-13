using Microsoft.Xna.Framework;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Objects.Enemy
{
    public class KoopaNormalState : IEnemyHealthState
    {
        private readonly Koopa koopa;
        public KoopaNormalState(Koopa koopa)
        {
            this.koopa = koopa;
            koopa.Score = GeneralConstants.DefaultEnemyScore;
        }

        public void Stomped()
        {
            koopa.HealthState = new KoopaShelledState(koopa);
        }

        public void Update(GameTime gameTime) { }
    }
}
