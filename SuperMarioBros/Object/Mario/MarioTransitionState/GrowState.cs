using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Marios;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.Objects.Mario.TransitionState;

namespace SuperMarioBros.Objects.Mario.MarioTransitionState
{
    public class GrowState : IMarioTransitionState
    {
        private readonly IMario mario;
        private double transitionTimer = .5d;
        private int index;
        private readonly float[] scales = {0.8f, 1f };
        public GrowState(IMario mario)
        {
            this.mario = mario;
            mario.NoMovementTimer = transitionTimer;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(mario.HealthState is BigMario)
                mario.Sprite.Draw(spriteBatch, mario.Position,SpriteEffects.None,scales[index % scales.Length]);
            else
                mario.Sprite.Draw(spriteBatch, mario.Position);
        }

        public void TakeRedMushroom() // Not likely to happen
        {
            mario.HealthState.TakeRedMushroom();
            mario.NoMovementTimer = .5d;
            transitionTimer = .5d;
        }

        public void TakeDamage()
        {
            //Do Nothing
        }

        public void TakeStar()
        {
            mario.TransitionState = new StarState(mario);
        }

        public void Update(GameTime gameTime)
        {
            index++;
            transitionTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (transitionTimer <= 0) mario.TransitionState = new NormalState(mario);
        }

        public void OnFireFlower()
        {
            mario.HealthState.TakeFireFlower();
            mario.NoMovementTimer = .5d;
            transitionTimer = .5d;
        }
    }
}
