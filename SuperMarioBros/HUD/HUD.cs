using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Stats;

namespace SuperMarioBros.HeadsUps
{
    public class HUD
    {
        private SpriteFont spriteFont;
        private readonly float scoreOffset = 83;
        private readonly float coinOffset = 246;
        private readonly float worldOffset = 400;
        private readonly float timeOffset = 532;
        private readonly float livesOffset = 666;
        public HUD(MarioGame game)
        {
            spriteFont = game.Content.Load<SpriteFont>("Font/MarioFont");
        }
        public void Draw(SpriteBatch spriteBatch, float leftBound, float upperBound)
        {
            DrawHelper(spriteBatch, "SCORE", new Vector2(scoreOffset + leftBound, 5 + upperBound));
            DrawHelper(spriteBatch, StatsManager.Instance.Score.ToString(), new Vector2(scoreOffset + leftBound + 10, 30 + upperBound));

            DrawHelper(spriteBatch, "COINS", new Vector2(coinOffset + leftBound, 5 + upperBound));
            DrawHelper(spriteBatch, StatsManager.Instance.Coin.ToString(), new Vector2(coinOffset + leftBound + 10, 30 + upperBound));

            DrawHelper(spriteBatch, "WORLD", new Vector2(worldOffset + leftBound, 5 + upperBound));
            DrawHelper(spriteBatch, "1-1", new Vector2(worldOffset + leftBound + 10, 30 + upperBound));

            DrawHelper(spriteBatch, "TIME", new Vector2(timeOffset + leftBound, 5 + upperBound));
            DrawHelper(spriteBatch, StatsManager.Instance.Time.ToString(), new Vector2(timeOffset + leftBound + 10, 30 + upperBound));

            DrawHelper(spriteBatch, "LIVES", new Vector2(livesOffset + leftBound, 5 + upperBound));
            DrawHelper(spriteBatch, StatsManager.Instance.Life.ToString(), new Vector2(livesOffset + leftBound + 32, 30 + upperBound));
        }

        private void DrawHelper(SpriteBatch spriteBatch, string str, Vector2 position)
        {
            spriteBatch.DrawString(spriteFont, str, position, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
        }
    }
}
