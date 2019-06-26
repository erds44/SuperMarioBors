using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Objects.Enemy
{
    public class GoombaIdleState : IEnemyMovementState
    {
        public GoombaIdleState(Goomba goomba)
        {
            goomba.Sprite = SpriteFactory.CreateSprite(goomba.HealthState.GetType().Name);
            goomba.Physics.Velocity = Vector2.Zero;
        }

        public void ChangeDirection()
        {
            // Do Nothing
        }

        public void MoveLeft()
        {
            // Do Nothing
        }

        public void MoveRight()
        {
            // Do Nothing
        }

        public void Stomped()
        {
            // Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            //Do Nothing
        }
    }
}
