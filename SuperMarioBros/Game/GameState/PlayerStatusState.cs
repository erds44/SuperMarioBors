using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Marios.MarioTypeStates;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.GameStates
{
    public class PlayerStatusState : IGameState
    {
        private GraphicsDevice graphicsDevice;
        private SpriteFont spriteFont;
        private ISprite smallMarioSprite;
        private float timer = 2f;
        public PlayerStatusState(GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.graphicsDevice = graphicsDevice;
           spriteFont = content.Load<SpriteFont>("Font/MarioFont");
            smallMarioSprite = SpriteFactory.CreateSprite(nameof(SmallMario) + nameof(RightIdle));
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            graphicsDevice.Clear(Color.Black);
            MarioGame.Instance.HeadsUps.Draw(spriteBatch, MarioGame.Instance.Camera.LeftBound, MarioGame.Instance.Camera.UpperBound);
            spriteBatch.DrawString(spriteFont, "WORLD 1-1 " , new Vector2(350, 140), Color.White);
            smallMarioSprite.Draw(spriteBatch, new Vector2(332, 262));
            spriteBatch.DrawString(spriteFont, "  X   " + MarioGame.Instance.HeadsUps.Lives, new Vector2(382, 240), Color.White);
            spriteBatch.End();
        }

        public void Pause()
        {
           // Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (timer <= 0)
            {
                MarioGame.Instance.State = new GameState(graphicsDevice);
            }                
        }
    }
}
