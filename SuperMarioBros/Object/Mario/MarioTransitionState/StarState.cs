using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects.Mario.TransitionState;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Objects.Mario.MarioTransitionState
{
    public class StarState : IMarioTransitionState
    {
        private IMario mario;
        private Collection<Color> starColor = new Collection<Color> { Color.Green, Color.Black, Color.White };
        private Collection<Color> normalColor = new Collection<Color> { Color.White };
        private double transitionTimer = 5d;
        public StarState(IMario mario)
        {
            this.mario = mario;
            mario.NoMovementTimer = 0;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            mario.Sprite.SetColor(starColor);
            mario.Sprite.Draw(spriteBatch, mario.Position);
            mario.Sprite.SetColor(normalColor);
        }

        public void OnFireFlower()
        {
            mario.HealthState.OnFireFlower();
        }

        public void TakeRedMushroom()
        {
            mario.HealthState.TakeRedMushroom();
        }

        public void TakeDamage()
        {
            // DO Nothing
        }

        public void TakeStar()
        {
            transitionTimer = 5d;
        }

        public void Update(GameTime gameTime)
        {
            transitionTimer -= gameTime.ElapsedGameTime.TotalSeconds;
            if (transitionTimer <= 0) mario.TransitionState = new NormalState(mario);
        }
    }
}
