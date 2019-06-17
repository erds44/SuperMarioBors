using SuperMarioBros.Collisions;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftCrouching : AbstractMovementState,IMarioMovementState
    {
        public LeftCrouching(IMario mario)
        {
            this.mario = mario;
            mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public void Down()
        {

        }

        public void Idle()
        {
            mario.MovementState = new LeftIdle(mario);
        }

        public void Left()
        {

        }


        public void Right()
        {

        }


        public void Up()
        {
            // Physics
        }


        public void Update()
        {
            // Do Nothing
        }
        public void MoveUp()
        {
            mario.MarioPhysics.MoveUp();
        }

    }
}
