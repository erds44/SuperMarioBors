using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftJumping : AbstractMovementState, IMarioMovementState
    {
        public LeftJumping(IMario mario, Physics marioPhysics)
        {
            this.mario = mario;
            this.marioPhysics = marioPhysics;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
            
        }

        public void ChangeSprite()
        {
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public void Down()
        {
            mario.MovementState = new LeftIdle(mario,marioPhysics);
        }

        public void Idle()
        {
            mario.MovementState = new LeftIdle(mario,marioPhysics);
        }

        public void Left()
        {
           marioPhysics.Left();
        }

        public void Right()
        {
            marioPhysics.Right();
        }

        public void Up()
        {
            marioPhysics.Up();
        }

        public void Update()
        {
            //marioPhysics.Up();
        }
    }
}
