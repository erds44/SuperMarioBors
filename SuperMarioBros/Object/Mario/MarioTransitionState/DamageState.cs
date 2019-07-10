using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects.Mario.TransitionState;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Objects.Mario.MarioTransitionState
{
    public class DamageState : IMarioTransitionState
    {
        private readonly IMario mario;
        private readonly Collection<Color> growColor = new Collection<Color> { Color.White, Color.White * 0.5f };       
        private float transitionTimer = 2f;
        private readonly double nonMovementTimer = .5d;
        private int colorIndex = 0;
        private float delay = 0.1f;
        public DamageState(IMario mario)
        {
            this.mario = mario;
            mario.NoMovementTimer = nonMovementTimer;
            AudioFactory.Instance.CreateSound("pipe").Play(); //Surprisingly, taking damage and going into pipe has the same sound.
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            mario.Sprite.Draw(spriteBatch, mario.Position,growColor[colorIndex]);
        }

        public void TakeRedMushroom() // Not very likely
        {
            mario.HealthState.TakeRedMushroom();
            mario.TransitionState = new GrowState(mario);
        }

        public void TakeDamage()
        {
            // Do Nothing
        }

        public void TakeStar()
        {
            mario.TransitionState = new StarState(mario);
        }

        public void Update(GameTime gameTime)
        {
            transitionTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            delay -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (transitionTimer <= 0) mario.TransitionState = new NormalState(mario);
            if (delay <= 0)
            {
                delay = 0.1f;
                colorIndex++;
                colorIndex = colorIndex % growColor.Count;
            }
        }

        public void OnFireFlower() // not likely to happen
        {
            // Do Nothing
        }
    }
}
