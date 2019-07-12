using Microsoft.Xna.Framework;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Objects.Enemy
{
    public class GoombaStompedState : IEnemyHealthState
    {
        private readonly Goomba goomba;
        private float deleteTimer = Timers.StompedGoombaTimeSpan;
        public GoombaStompedState(Goomba goomba)
        {
            this.goomba = goomba;
        }

        public void Stomped()
        {
            // Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            deleteTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (deleteTimer <= 0)
                goomba.ObjState = ObjectState.Destroy;
        }
    }
}
