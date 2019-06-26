using Microsoft.Xna.Framework;

namespace SuperMarioBros.Objects.Enemy
{
    public class KoopaNormalState : IEnemyHealthState
    {
        private readonly Koopa koopa;
        public KoopaNormalState(Koopa koopa)
        {
            this.koopa = koopa;
        }

        public void Stomped()
        {
            koopa.HealthState = new KoopaShelledState(koopa);
        }

        public void Update(GameTime gameTime)
        {
            //Do Nothing
        }
    }
}
