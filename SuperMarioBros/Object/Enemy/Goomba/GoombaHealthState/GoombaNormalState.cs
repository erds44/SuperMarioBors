using Microsoft.Xna.Framework;

namespace SuperMarioBros.Objects.Enemy
{
    public class GoombaNormalState : IEnemyHealthState
    {
        private readonly Goomba goomba;
        public GoombaNormalState(Goomba goomba)
        {
            this.goomba = goomba;
        }

        public void Stomped()
        {
            goomba.HealthState = new GoombaStompedState(goomba);
        }

        public void Update(GameTime gameTime)
        {
            //Do Nothing
        }
    }
}
