using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects.Mario.TransitionState;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Objects.Mario.MarioTransitionState
{
    public class StarState : IMarioTransitionState
    {
        private readonly IMario mario;
        private readonly Collection<Color> starColor = new Collection<Color> { Color.Black, Color.White, Color.Green};
        private readonly Collection<Color> normalColor = new Collection<Color> { Color.White };
        private double transitionTimer = 5000d;
        private readonly Song lastSong;
        public StarState(IMario mario)
        {
            this.mario = mario;
            mario.NoMovementTimer = 0;
            lastSong = MediaPlayer.Queue.ActiveSong;
            MediaPlayer.Play(AudioFactory.Instance.CreateSong("starman"));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            mario.Sprite.SetColor(starColor);
            mario.Sprite.Draw(spriteBatch, mario.Position);
            mario.Sprite.SetColor(normalColor);
        }

        public void OnFireFlower()
        {
            mario.HealthState.TakeFireFlower();
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
            if (transitionTimer <= 0)
            {
                mario.TransitionState = new NormalState(mario);
                MediaPlayer.Play(lastSong);
            }
        }
    }
}
