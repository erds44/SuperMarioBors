using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace SuperMarioBros
{
    public class MarioGame : Game
    {
        private IController controller;
        public ISprite sprite;
        private SpriteBatch spriteBatch;
        private Vector2 location;
        private int count;
        public MarioGame()
        {
            var graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.DeviceCreated += (o, e) =>
            {
                spriteBatch = new SpriteBatch((o as GraphicsDeviceManager).GraphicsDevice);
            };
            Content.RootDirectory = "Content";
            count = 0;
        }
        protected override void Initialize()
        {
            location = new Vector2(400, 200);
            SpriteFactory.Instance.LoadAllTextures(Content); 
            if (GamePad.GetState(PlayerIndex.One).IsConnected)
            {
                controller = new GamePadController(this);
            }
            else
            {
                controller = new KeyboardController(this);
            }
            base.Initialize();
        }
        protected override void LoadContent()
        {
           // MarioSpriteFactory.Instance.LoadAllTextures(Content); ?
        }
        protected override void Update(GameTime gameTime)
        {
            count++;
            if(count % 4 == 0) // Used for delay
            {
                controller.Update();
                sprite.Update(ref location);
                base.Update(gameTime);
                count = 0;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            if (count % 4 == 0)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                sprite.Draw(spriteBatch);
                base.Draw(gameTime);
            }

        }

    }
}
