using Microsoft.Xna.Framework;

namespace SuperMarioBros.Objects.Enemy
{
    public class KoopaShelledState : IEnemyHealthState
    {
        private readonly Koopa koopa;
        private float respondingTimer = 5f;
        public KoopaShelledState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void Stomped()
        {
            // Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            if (koopa.Score != 500) koopa.Score = 500;
            respondingTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
