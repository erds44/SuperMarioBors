using Microsoft.Xna.Framework;

namespace SuperMarioBros.Objects.Enemy
{
    public class KoopaShelledState : IEnemyHealthState
    {
        private readonly Koopa koopa;
        public KoopaShelledState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void Stomped() { }

        public void Update(GameTime gameTime)
        {
            if (koopa.Score != 500) koopa.Score = 500;
        }
    }
}
