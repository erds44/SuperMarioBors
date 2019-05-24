using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Interface;
using SuperMarioBros.Class.Object.MarioObject;
using SuperMarioBros.Class.Controller;

namespace SuperMarioBros
{
    public class MarioGame : Game
    {
        private List<IController> controllers = new List<IController>();
        private SpriteBatch spriteBatch;
        private Vector2 location;
        private int count;
        private MarioObject mario;
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
            SpriteFactory.Initialize(Content); 
            controllers.Add(new GamePadController(this));
            controllers.Add(new KeyboardController(this));
            this.mario = new MarioObject(this, location);
            base.Initialize();
        }
        protected override void LoadContent()
        {
           // MarioSpriteFactory.Instance.LoadAllTextures(Content); ?
        }
        protected override void Update(GameTime gameTime)
        {
            count++;
            if(count % 5 == 0) // Used for delay
            {
                controllers.ForEach(element => element.Update());
                mario.Update();
                base.Update(gameTime);
                count = 0;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            if (count % 5 == 0)
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);
                mario.Draw(spriteBatch);
                base.Draw(gameTime);
            }

        }

    }
}
