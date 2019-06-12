using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using System;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public class LeftCrouching : AbstractMovementState,IMarioMovementState
    {
        public LeftCrouching(IMario mario, Physics marioPhysics)
        {
            this.mario = mario;
            this.marioPhysics = marioPhysics;
            mario.Sprite = SpriteFactory.CreateSprite(mario.HealthState.GetType().Name + GetType().Name);
        }

        public void Down()
        {
            marioPhysics.Down();
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
            mario.MovementState = new LeftIdle(mario, marioPhysics);
        }


        public void Update()
        {
            // Do Nothing
        }

    }
}
