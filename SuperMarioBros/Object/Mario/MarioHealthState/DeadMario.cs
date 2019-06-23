using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioTypeStates
{
    public class DeadMario : IMarioHealthState
    {
        public DeadMario(IMario mario)
        {
            mario.ObjState = ObjectState.NonCollidable;
            mario.Sprite = SpriteFactory.CreateSprite(nameof(DeadMario));
            mario.MovementState = new TerminateMovementState();
            mario.MarioPhysics.SetXVelocity(0);
            mario.MarioPhysics.SetYVelocity(-150);
        }

        public void Coin()
        {
            // To Do
        }

        public void OnFireFlower()
        {
            // Do Nothing
        }

        public void GreenMushroom()
        {
           // Do Nothing
        }

        public void RedMushroom()
        {
            // Do Nothing
        }

        public void TakeDamage()
        {
            // Do Nothing
        }
        public void Power()
        {
            // Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            // Do nothing.
        }
    }
}
