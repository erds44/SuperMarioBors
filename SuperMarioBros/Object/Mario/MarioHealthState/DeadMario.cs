using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Stats;

namespace SuperMarioBros.Marios.MarioTypeStates
{
    public class DeadMario : IMarioHealthState
    {
        private Vector2 DeadVelocity = new Vector2(0, -150);
        public DeadMario(IMario mario)
        {
            if(mario.ObjState == ObjectState.Normal) mario.ObjState = ObjectState.NonCollidable;
            mario.Sprite = SpriteFactory.CreateSprite(nameof(DeadMario));
            mario.MovementState = new TerminateMovementState();
            mario.Physics.Velocity = DeadVelocity;
            MediaPlayer.Play(AudioFactory.Instance.CreateSong("youredead"));
            StatsManager.Instance.LoseLife();
        }

        public void TakeDamage() { }

        public void Update(GameTime gameTime) { }

        public void TakeRedMushroom() { }

        public void TakeFireFlower() { }

        public void PowerPressed() { }

        public void PowerReleased() { }
    }
}
