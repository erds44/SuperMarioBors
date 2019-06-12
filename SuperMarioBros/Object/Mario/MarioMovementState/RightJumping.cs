using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightJumping : AbstractMovementState, IMarioMovementState
    {
        public RightJumping(IMario mario,  Physics marioPhysics)
        {
            this.mario = mario;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
            this.marioPhysics = marioPhysics;
        }

        public void Down()
        {
            mario.MovementState = new RightIdle(mario, marioPhysics);
        }

        public void Right()
        {
            marioPhysics.Right();
        }

        public void Left()
        {
            marioPhysics.Left();
        }

        public void Up()
        {
            marioPhysics.Up();
        }

        public void Update()
        {
            //marioPhysics.Up();
        }


        public void Idle()
        {
            mario.MovementState= new RightIdle(mario, marioPhysics);
        }
    }
}
