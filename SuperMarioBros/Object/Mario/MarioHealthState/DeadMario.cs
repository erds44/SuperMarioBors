using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Marios.MarioTypeStates
{
    public class DeadMario : IMarioHealthState
    {
        private Vector2 DeadVelocity = new Vector2(0, -150);
        public DeadMario(IMario mario)
        {
            mario.ObjState = ObjectState.NonCollidable;
            mario.Sprite = SpriteFactory.CreateSprite(nameof(DeadMario));
            mario.MovementState = new TerminateMovementState();
            mario.Physics.Velocity = DeadVelocity;
            MediaPlayer.Stop();
            AudioFactory.Instance.CreateSound("mariodie").Play();
        }

        public void TakeDamage()
        {
            // Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            // Do nothing
        }

        public void TakeRedMushroom()
        {
            // Do Nothing
        }

        public void OnFireFlower()
        {
            // Do Nothing
        }
    }
}
