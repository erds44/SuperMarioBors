using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;
using SuperMarioBros.Stats;
using SuperMarioBros.Utility;
using static SuperMarioBros.Utility.Locations;
namespace SuperMarioBros.GameStates
{
    public class PlayerStatusState : GameState
    {
        private readonly GraphicsDevice graphicsDevice;
        private readonly SpriteFont spriteFont;
        private readonly ISprite smallMarioSprite;
        private float timer = Timers.StatusTimeSpan;
        private readonly MarioGame game;
        public PlayerStatusState(MarioGame game)
        {
            this.game = game;
            game.IsMouseVisible = false;
            game.DisableController();
            graphicsDevice = game.GraphicsDevice;
            spriteFont = game.Content.Load<SpriteFont>(StringConsts.MarioFont);
            smallMarioSprite = SpriteFactory.CreateSprite(nameof(SmallMario) + nameof(RightIdle));
            game.IsMouseVisible = false;
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            graphicsDevice.Clear(Color.Black);
            game.Hud.Draw(spriteBatch, Origin, Origin);
            DrawPlayerAndWorldInfo(spriteBatch);          
            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0) game.State = new PlayingState(game);
        }

        private void DrawPlayerAndWorldInfo(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(spriteFont, StringConsts.World, WorldOffest, Color.White);
            smallMarioSprite.Draw(spriteBatch, IconOffest);
            spriteBatch.DrawString(spriteFont, StringConsts.Life+ StatsManager.Instance.Life, StatuLifeOffset, Color.White);
        }
    }
}
