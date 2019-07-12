using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Objects.Enemy
{
    public class GoombaLeftMovingState : IEnemyMovementState
    {
        private readonly Goomba goomba;
        public GoombaLeftMovingState(Goomba goomba)
        {
            this.goomba = goomba;
            goomba.Sprite = SpriteFactory.CreateSprite(GetType().Name);
            goomba.Physics.Velocity = PhysicsConsts.LeftMovingGoombaVelocity;
        }

        public void ChangeDirection()
        {
            goomba.MovementState = new GoombaRightMovingState(goomba);
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
            //Do Nohitng
        }
    }
}
