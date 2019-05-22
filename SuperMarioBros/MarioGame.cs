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
    class MarioGame : Game
    {
        private IController controller;
        public ISprite sprite;
        private SpriteBatch spriteBatch;
        private Vector2 location;
        public MarioGame()
        {
            var graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.DeviceCreated += (o, e) =>
            {
                spriteBatch = new SpriteBatch((o as GraphicsDeviceManager).GraphicsDevice);
            };
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            location = new Vector2(400, 200);
            MarioSpriteFactory.Instance.LoadAllTextures(Content); 
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
            controller.Update();
            sprite.Update(ref location);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            sprite.Draw(spriteBatch);
            base.Draw(gameTime);
        }

    }
}
