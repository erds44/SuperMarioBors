using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class RightCrouching : AbstractMovementState, IMarioMovementState
    { 
        public RightCrouching(IMario mario,Physics marioPhysics)
        {
            this.mario = mario;
            this.marioPhysics = marioPhysics;
            this.mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public void Down()
        {
            marioPhysics.Down();
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
            mario.MovementState = new RightIdle(mario,marioPhysics);
        }
     
        public void Update()
        {
            // Do nothing.
        }

        public void ChangeSprite()
        {
            string type = mario.HealthState.GetType().Name;
            if (!(mario.HealthState is SmallMario))
            {
                mario.Sprite = SpriteFactory.CreateSprite(type + GetType().Name);
            }
            else
            {
                mario.Sprite = SpriteFactory.CreateSprite(type + nameof(RightIdle));
            }
        }

        public void Idle()
        {
            mario.MovementState = new RightIdle(mario,marioPhysics);
        }
    }
}
