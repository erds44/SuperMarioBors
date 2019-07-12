﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;
using SuperMarioBros.Stats;

namespace SuperMarioBros.GameStates
{
    public class PlayerStatusState : GameState
    {
        private readonly GraphicsDevice graphicsDevice;
        private readonly SpriteFont spriteFont;
        private readonly ISprite smallMarioSprite;
        private float timer = 3f;
        private readonly MarioGame game;
        public PlayerStatusState(MarioGame game)
        {
            this.game = game;
            game.IsMouseVisible = false;
            game.DisableController();
            graphicsDevice = game.GraphicsDevice;
            spriteFont = game.Content.Load<SpriteFont>("Font/MarioFont");
            smallMarioSprite = SpriteFactory.CreateSprite(nameof(SmallMario) + nameof(RightIdle));
            game.IsMouseVisible = false;
            
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            graphicsDevice.Clear(Color.Black);
            game.Hud.Draw(spriteBatch, 0f, 0f);
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
            spriteBatch.DrawString(spriteFont, "WORLD 1-1 ", new Vector2(350, 140), Color.White);
            smallMarioSprite.Draw(spriteBatch, new Vector2(332, 262));
            spriteBatch.DrawString(spriteFont, "  X   " + StatsManager.Instance.Life, new Vector2(382, 240), Color.White);
        }
    }
}