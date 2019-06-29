using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Marios;
using System;

namespace SuperMarioBros.HeadsUps
{
    public class HeadsUp
    {
        private readonly ContentManager content;
        private readonly SpriteFont spriteFont;
        private float scoreOffset = 83;
        private float coinOffset = 246;
        private float wordOffset = 400;
        private float timeOffset = 532;
        private float livesOffset = 666;

        private float timer = 400;
        private int score = 0;
        private int coin = 0;
        private int lives = 3;
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
            spriteBatch.DrawString(spriteFont, "SCORE", new Vector2(scoreOffset + leftBound, 5), Color.White);
            spriteBatch.DrawString(spriteFont, score.ToString(), new Vector2(scoreOffset + 10 +leftBound, 30), Color.White);

            spriteBatch.DrawString(spriteFont, "COINS", new Vector2(coinOffset + leftBound, 5), Color.White);
            spriteBatch.DrawString(spriteFont, coin.ToString(), new Vector2(coinOffset + leftBound + 10, 30), Color.White);

            spriteBatch.DrawString(spriteFont, "WORLD", new Vector2(wordOffset + leftBound, 5), Color.White);
            spriteBatch.DrawString(spriteFont, "1-1", new Vector2(wordOffset + leftBound + 10, 30), Color.White);

            spriteBatch.DrawString(spriteFont, "TIME", new Vector2(timeOffset + leftBound, 5), Color.White);
            spriteBatch.DrawString(spriteFont, ((int)timer).ToString(), new Vector2(timeOffset + leftBound + 10, 30), Color.White);

            spriteBatch.DrawString(spriteFont, "LIVES", new Vector2(livesOffset + leftBound, 5), Color.White);
            spriteBatch.DrawString(spriteFont, lives.ToString(), new Vector2(livesOffset + leftBound + 10, 30), Color.White);
        }
        public void OnMarioDeath()
        {
            lives--;
        }
    }
}
