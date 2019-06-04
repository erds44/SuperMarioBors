using Microsoft.Xna.Framework;
using SuperMarioBros.Classes.Object;
using SuperMarioBros.Interfaces.Object;
using SuperMarioBros.Interfaces.State;

namespace SuperMarioBros.Classes.Objects.MarioObjects.MarioMovementState
{
    public class LeftJumpingMarioState : IMarioMovementState
    {
        private readonly IMario mario;
        private string type;
        private readonly Physics marioPhysics;
        public LeftJumpingMarioState(IMario mario, string type, Physics marioPhysics)
        {
            this.mario = mario;
            this.type = type;
            this.marioPhysics = marioPhysics;
            this.mario.ChangeSprite(SpriteFactory.CreateSprite(type + "LeftJumping"));
            
        }

        public void ChangeSprite(string type)
        {
            this.type = type;
            this.mario.ChangeSprite(SpriteFactory.CreateSprite(type + "LeftJumping"));
        }

        public void Down()
        {
            mario.ChangeMovementState(new LeftIdleMarioState(mario,type, marioPhysics));
        }

        public void Idle()
        {
            mario.ChangeMovementState(new LeftIdleMarioState(mario, type, marioPhysics));
        }

        public void Left()
        {
           marioPhysics.Left();
        }

        public void Right()
        {
           // Do Nothing
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
