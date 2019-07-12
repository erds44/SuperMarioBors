using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Objects.Enemy
{
    public class GoombaRightMovingState : IEnemyMovementState
    {
        private readonly Goomba goomba;
        public GoombaRightMovingState (Goomba goomba)
        {
            this.goomba = goomba;
            goomba.Sprite = SpriteFactory.CreateSprite(GetType().Name);
            goomba.Physics.Velocity = PhysicsConsts.RightMovingGoombaVelocity;
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
