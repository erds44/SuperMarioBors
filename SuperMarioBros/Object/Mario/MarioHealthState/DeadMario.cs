using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Stats;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Marios.MarioTypeStates
{
    public class DeadMario : IMarioHealthState
    {
        public DeadMario(IMario mario)
        {
            if(mario.ObjState == ObjectState.Normal) mario.ObjState = ObjectState.NonCollidable;
            mario.Sprite = SpriteFactory.CreateSprite(nameof(DeadMario));
            mario.MovementState = new TerminateMovementState();
            mario.Physics.Velocity = PhysicsConsts.DeadMarioVelocity;
            MediaPlayer.Play(AudioFactory.Instance.CreateSong(Strings.Dead));
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
