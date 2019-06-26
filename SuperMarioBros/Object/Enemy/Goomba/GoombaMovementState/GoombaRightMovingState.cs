using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Objects.Enemy
{
    public class GoombaRightMovingState : IEnemyMovementState
    {
        private readonly Goomba goomba;
        private readonly Vector2 rightMovingVelocity = new Vector2(60, 0);
        public GoombaRightMovingState (Goomba goomba)
        {
            this.goomba = goomba;
            goomba.Sprite = SpriteFactory.CreateSprite(GetType().Name);
            goomba.Physics.Velocity = rightMovingVelocity;
        }

        public void ChangeDirection()
        {
            goomba.MovementState = new GoombaLeftMovingState(goomba);
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
            goomba.MovementState = new GoombaIdleState(goomba);
        }

        public void Update(GameTime gameTime)
        {
           //Do Nothing
        }
    }
}
