using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Stats;
using SuperMarioBros.Utility;
using static SuperMarioBros.Utility.Layers;
using static SuperMarioBros.Utility.Locations;

namespace SuperMarioBros.HeadsUps
{
    public class HUD
    {
        private SpriteFont spriteFont;
        public HUD(MarioGame game)
        {
            spriteFont = game.Content.Load<SpriteFont>(StringConsts.MarioFont);
        }
        public void Draw(SpriteBatch spriteBatch, float leftBound, float upperBound)
        {
            DrawHelper(spriteBatch, StringConsts.ScoreInfo, new Vector2(ScoreStringOffset + leftBound, WordXOffset + upperBound));
            DrawHelper(spriteBatch, StatsManager.Instance.Score.ToString(), new Vector2(ScoreStringOffset + leftBound, WordYOffset + upperBound));

            DrawHelper(spriteBatch, StringConsts.CoinInfo, new Vector2(CoinStringOffset + leftBound, WordXOffset + upperBound));
            DrawHelper(spriteBatch, StatsManager.Instance.Coin.ToString(), new Vector2(CoinStringOffset + leftBound, WordYOffset + upperBound));

            DrawHelper(spriteBatch, StringConsts.WorldInfo, new Vector2(WorldStringOffset + leftBound, WordXOffset + upperBound));
            DrawHelper(spriteBatch, StringConsts.LevelInfo, new Vector2(WorldStringOffset + leftBound, WordYOffset + upperBound));

            DrawHelper(spriteBatch, StringConsts.TimeInfo, new Vector2(TimeStringOffset + leftBound, WordXOffset + upperBound));
            DrawHelper(spriteBatch, StatsManager.Instance.Time.ToString(), new Vector2(TimeStringOffset + leftBound, WordYOffset + upperBound));

            DrawHelper(spriteBatch, StringConsts.LivesInfo, new Vector2(LivesStringOffset + leftBound, WordXOffset + upperBound));
            DrawHelper(spriteBatch, StatsManager.Instance.Life.ToString(), new Vector2(LivesStringOffset + leftBound, WordYOffset + upperBound));
        }

        private void DrawHelper(SpriteBatch spriteBatch, string str, Vector2 position)
        {
            spriteBatch.DrawString(spriteFont, str, position, Color.White, HeadsUpRotation, Vector2.Zero, HeadsUpScale, SpriteEffects.None, HeadsUpLayer);
        }
    }
}
