using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.HeadsUps
{
    public class HeadsUp
    {
        private readonly ContentManager content;
        private readonly SpriteFont spriteFont;
        private float scoreOffset = 83;
        private float coinOffset = 246;
        private float worldOffset = 400;
        private float timeOffset = 532;
        private float livesOffset = 666;

        private float timer = 400;
        private int score = 0;
        private int coin = 0;
        private int lives = 3;
        private readonly Dictionary<Type, int> itemDictionary = new Dictionary<Type, int>
        {
            { typeof(Coin), 200},
            { typeof(RedMushroom), 1000}
        };
        public HeadsUp(ContentManager contentManager)
        {
            content = contentManager;
            spriteFont = content.Load<SpriteFont>("Font");
        }
        public void Update(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        public void Draw (SpriteBatch spriteBatch, float leftBound)
        {
            DrawHelper(spriteBatch, "SCORE", new Vector2(scoreOffset + leftBound, 5));
            DrawHelper(spriteBatch, score.ToString(), new Vector2(scoreOffset + leftBound + 10, 30));

            DrawHelper(spriteBatch, "COINS", new Vector2(coinOffset + leftBound, 5));
            DrawHelper(spriteBatch, coin.ToString(), new Vector2(coinOffset + leftBound + 10, 30));

            DrawHelper(spriteBatch, "WORLD", new Vector2(worldOffset + leftBound, 5));
            DrawHelper(spriteBatch, "1-1", new Vector2(worldOffset + leftBound + 10, 30));

            DrawHelper(spriteBatch, "TIME", new Vector2(timeOffset + leftBound, 5));
            DrawHelper(spriteBatch, ((int)timer).ToString(), new Vector2(timeOffset + leftBound + 10, 30));

            DrawHelper(spriteBatch, "LIVES", new Vector2(livesOffset + leftBound, 5));
            DrawHelper(spriteBatch, lives.ToString(), new Vector2(livesOffset + leftBound + 10, 30));
        }
        public void OnMarioDeath()
        {
            lives--;
        }
        public void CoinCollected(Vector2 Position)
        {
            coin++;
            score += 200;
            ObjectFactory.Instance.CreateScoreText(Position, spriteFont, "200");
        }
        public void EnemyStomped(Vector2 Position)
        {
            score += 100;
            ObjectFactory.Instance.CreateScoreText(Position, spriteFont, "100");
        }
        public void ResetTimer()
        {
            timer = 400;
        }
        public void ExtraLife(Vector2 Position)
        {
            lives++;
            ObjectFactory.Instance.CreateScoreText(Position, spriteFont, "1LF");
        }
        public void PowerUpCollected(Vector2 Position)
        {
            score += 1000;
            ObjectFactory.Instance.CreateScoreText(Position, spriteFont, "1000");
        }
        private void DrawHelper(SpriteBatch spriteBatch, string str, Vector2 position)
        {
            spriteBatch.DrawString(spriteFont, str, position, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }
    }
}
