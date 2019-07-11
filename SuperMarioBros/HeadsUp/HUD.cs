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
    public class HUD
    {
        public event Action TimeOverEvent;
        private readonly SpriteFont spriteFont;
        private readonly float scoreOffset = 83;
        private readonly float coinOffset = 246;
        private readonly float worldOffset = 400;
        private readonly float timeOffset = 532;
        private readonly float livesOffset = 666;
        private bool clearingScores = false;
        private readonly MarioGame game;
        public float Timer { get; private set; } = 400;
        private int score = 0;
        private int coin = 0;
        public int Lives { get; set; }
        public HUD(MarioGame game)
        {
            this.game = game;
            spriteFont = game.Content.Load<SpriteFont>("Font/MarioFont");
            Lives = 3;
        }
        public void Update(GameTime gameTime)
        {
            Timer -= 2 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (clearingScores)
            {
                if (Timer > 0)
                    CountTimeBonusScore();
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
                    TimeOverEvent?.Invoke();
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
        public void EnemyStomped(Vector2 position,int score, int count)
        {
            int addScore = score * count;
            this.score += addScore;
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
            Timer = 400; // Reset timer to 400 seconds.
            coin = 0; //Reset coin count.
            score = 0; //Reset score count.
            Lives = 3; // Has 3 lives.
        }
        public void ExtraLife(Vector2 Position)
        {
            Lives++;
            AudioFactory.Instance.CreateSound("1up").Play();
            ObjectFactory.Instance.CreateScoreText(Position, spriteFont, "1LF");
        }
        public void PowerUpCollected(Vector2 Position)
        {
            score += 1000; //PowerUp Bonus.
            AudioFactory.Instance.CreateSound("powerup").Play();
            ObjectFactory.Instance.CreateScoreText(Position, spriteFont, "1000");
        }

        public void ClearingScores()
        {
            clearingScores = true;
            ((FlagPoleState)game.State).UpdateHeadsUp = true;
        }

        private void DrawHelper(SpriteBatch spriteBatch, string str, Vector2 position)
        {
            spriteBatch.DrawString(spriteFont, str, position, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }

        private void CountTimeBonusScore()
        {
            if(Timer <= 3)
            {
                score += (int)Timer * 100; //100 score for each sec remain.
                Timer = 0;
            }
            else
            {
                Timer -= 3; //Use 3 as count unit.
                score += 300; //100 score for each sec remain.
            }
        }
    }
}
