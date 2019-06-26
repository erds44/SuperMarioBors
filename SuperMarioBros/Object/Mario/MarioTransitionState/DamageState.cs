using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Marios;
using SuperMarioBros.Object.Mario.TransitionState;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Object.Mario.MarioTransitionState
{
    public class DamageState : IMarioTransitionState
    {
        private IMario mario;
        private readonly Collection<Color> growColor = new Collection<Color> { Color.White, Color.White * 0.5f }; // needed to be fixed
        private readonly Collection<Color> normalColor = new Collection<Color> { Color.White };
        private double transitionTimer = 5d;
        private double nonMovementTimer = 2.5d;
        public DamageState(IMario mario)
        {
            this.mario = mario;
            mario.NoMovementTimer = nonMovementTimer;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            mario.Sprite.SetColor(growColor);
            mario.Sprite.Draw(spriteBatch, mario.Position);
            mario.Sprite.SetColor(normalColor);
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
            transitionTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (transitionTimer <= 0) mario.TransitionState = new NormalState(mario);
        }

        public void OnFireFlower() // not likely to happen
        {
            // Do Nothing
        }
    }
}
