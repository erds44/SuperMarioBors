using SuperMarioBros.Collisions;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftMoving : AbstractMovementState, IMarioMovementState
    {
        public LeftMoving(IMario mario)
        {
            this.mario = mario;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public void Down()
        {
            if (!(mario.HealthState is SmallMario))
            {
                mario.MovementState = new LeftCrouching(mario);
            }
        }

        public void Idle()
        {
            mario.MarioPhysics.SpeedDecay();
            if ((int)mario.MarioPhysics.XVelocity >= 0)
            {
                mario.MovementState = new LeftIdle(mario);
            }
        }

        public void Left()
        {
            mario.MarioPhysics.Left();
        }


        public void Right()
        {
            mario.MovementState = new LeftBreaking(mario);          
        }

        public void Up()
        {
            mario.MovementState = new LeftJumping(mario);
        }

        public void MoveUp()
        {
            mario.MarioPhysics.MoveUp();
        }

        public void Update()
        {
            if (mario.MarioPhysics.Jump)
                mario.MovementState = new LeftJumping(mario);
        }
    }
}
