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
            koopa.Score = 500;
        }

        public void Stomped()
        {
            // Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            respondingTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (respondingTimer <= 0)
            {
                koopa.HealthState = new KoopaNormalState(koopa);
                koopa.IsStomped = true;
            }
        }
    }
}
