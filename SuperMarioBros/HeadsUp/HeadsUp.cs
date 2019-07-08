using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.GameStates;
using SuperMarioBros.Items;
using SuperMarioBros.Objects;
using System;

namespace SuperMarioBros.HeadsUps
{
    public class HeadsUp
    {
        public event Action timerOverEvent;
        private readonly SpriteFont spriteFont;
        private readonly float scoreOffset = 83;
        private readonly float coinOffset = 246;
        private readonly float worldOffset = 400;
        private readonly float timeOffset = 532;
        private readonly float livesOffset = 666;
        private bool clearingScores = false;
        private readonly MarioGame game;
        public float Timer { get; private set; } = 120;
        private int score = 0;
        private int coin = 0;
        public int Lives { get; set; }
        public HeadsUp(MarioGame game)
        {
            this.game = game;
            spriteFont = game.Content.Load<SpriteFont>("Font/MarioFont");
            Lives = 3;
        }
        public void Update(GameTime gameTime)
        {
            Timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (clearingScores)
            {
                if (Timer > 0)
                    DecreasingValues();
                else
                {
                    ObjectFactory.Instance.CreateNonCollidableObject(typeof(WinFlag), new Vector2(8620, 410));
                    if(game.State is FlagPoleState state)
                        state.UpdateHeadsUp = false;
                }                   
            }
            else
            {
                if (Timer <= 0)
                {
                    timerOverEvent?.Invoke();
                    Timer = 0;
                }
            }
        }
        public void Draw(SpriteBatch spriteBatch, float leftBound, float upperBound)
        {
            DrawHelper(spriteBatch, "SCORE", new Vector2(scoreOffset + leftBound, 5 + upperBound));
            DrawHelper(spriteBatch, score.ToString(), new Vector2(scoreOffset + leftBound + 10, 30 + upperBound));

            DrawHelper(spriteBatch, "COINS", new Vector2(coinOffset + leftBound, 5 + upperBound));
            DrawHelper(spriteBatch, coin.ToString(), new Vector2(coinOffset + leftBound + 10, 30 + upperBound));

            DrawHelper(spriteBatch, "WORLD", new Vector2(worldOffset + leftBound, 5 + upperBound));
            DrawHelper(spriteBatch, "1-1", new Vector2(worldOffset + leftBound + 10, 30 + upperBound));

            DrawHelper(spriteBatch, "TIME", new Vector2(timeOffset + leftBound, 5 + upperBound));
            DrawHelper(spriteBatch, ((int)Timer).ToString(), new Vector2(timeOffset + leftBound + 10, 30 + upperBound));

            DrawHelper(spriteBatch, "LIVES", new Vector2(livesOffset + leftBound, 5 + upperBound));
            DrawHelper(spriteBatch, Lives.ToString(), new Vector2(livesOffset + leftBound + 32, 30 + upperBound));
        }
        public void OnMarioDeath()
        {
            Lives--;
            if (Lives == 0)
                game.ChangeToGameOvertState();
            else
                game.ChangeToPlayerStatusState();
        }
        public void CoinCollected(Vector2 Position)
        {
            coin++;
            score += 200;
            AudioFactory.Instance.CreateSound("coin").Play();
            ObjectFactory.Instance.CreateScoreText(Position, spriteFont, "200");
        }
        public void EnemyStomped(Vector2 position, int count)
        {
            int addScore = 100 * count;
            score += addScore;
            AudioFactory.Instance.CreateSound("stomp").Play();
            ObjectFactory.Instance.CreateScoreText(position, spriteFont, addScore.ToString());
        }

        public void AddFlagScore(Vector2 position)
        {
            int flagScore = (int)(375 - position.Y) * (5000 / 304);
            ObjectFactory.Instance.CreateScoreText(position, spriteFont, flagScore.ToString());
            score += flagScore;
        }

        public void ResetTimer()
        {
            Timer = 400;
        }
        public void ResetAll()
        {
            Timer = 400;
            coin = 0;
            score = 0;
            Lives = 3;
        }
        public void ExtraLife(Vector2 Position)
        {
            Lives++;
            AudioFactory.Instance.CreateSound("1up").Play();
            ObjectFactory.Instance.CreateScoreText(Position, spriteFont, "1LF");
        }
        public void PowerUpCollected(Vector2 Position)
        {
            score += 1000;
            AudioFactory.Instance.CreateSound("powerup").Play();
            ObjectFactory.Instance.CreateScoreText(Position, spriteFont, "1000");
        }

        public void ClearingScores()
        {
            MediaPlayer.Play(AudioFactory.Instance.CreateSong("levelcomplete"));
            clearingScores = true;
            ((FlagPoleState)game.State).UpdateHeadsUp = true;
        }

        private void DrawHelper(SpriteBatch spriteBatch, string str, Vector2 position)
        {
            spriteBatch.DrawString(spriteFont, str, position, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }
        private void DecreasingValues()
        {
            if(Timer <= 3)
            {
                score += (int)(3 - Timer) * 100;
                Timer = 0;
            }
            else
            {
                Timer -= 3;
                score += 300;
            }
        }
    }
}
