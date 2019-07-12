using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects.Mario.TransitionState;
using SuperMarioBros.Utility;
using System.Collections.ObjectModel;

namespace SuperMarioBros.Objects.Mario.MarioTransitionState
{
    public class StarState : IMarioTransitionState
    {
        private readonly IMario mario;
        private readonly Collection<Color> starColor = new Collection<Color> { Color.Green, Color.Black, Color.White };
        private float transitionTimer = Timers.StarMarioTimeSpan;
        private readonly Song lastSong;
        private int colorIndex = SpriteConsts.MarioInitialColorIndex;
        private float delay = Timers.MarioUpdateDelay;
        public StarState(IMario mario)
        {
            this.mario = mario;
            mario.NoMovementTimer = 0;
            lastSong = MediaPlayer.Queue.ActiveSong;
            MediaPlayer.Play(AudioFactory.Instance.CreateSong(Strings.Star));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            mario.Sprite.Draw(spriteBatch, mario.Position, starColor[colorIndex]);
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
            transitionTimer = Timers.StarMarioTimeSpan;
        }

        public void Update(GameTime gameTime)
        {
            transitionTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            delay -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (transitionTimer <= 0)
            {
                mario.TransitionState = new NormalState(mario);
                MediaPlayer.Play(lastSong);
            }
            if(delay <= 0)
            {
                delay = Timers.MarioUpdateDelay;
                colorIndex++;
                colorIndex = colorIndex % starColor.Count;
            }
        }
    }
}
