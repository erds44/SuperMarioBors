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
using SuperMarioBros.Class.Object.GoombaObject;
using SuperMarioBros.Class.Object.ItemObject;

namespace SuperMarioBros
{
    public class MarioGame : Game
    {
        private List<IController> controllers = new List<IController>();
        private SpriteBatch spriteBatch;
        private Vector2 location;
        private int count;
        public MarioObject mario;
        public GoombaObject goomba;
        public PipeObject pipe;
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
            location = new Vector2(400, 300);
            SpriteFactory.Initialize(Content); 
            controllers.Add(new GamePadController(this));
            controllers.Add(new KeyboardController(this));
            mario = new MarioObject(this, location,"SmallMario");
            goomba = new GoombaObject(new Vector2(100, 100));
            pipe = new PipeObject(new Vector2(200, 200));
            base.Initialize();
        }
        protected override void LoadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            count++;
            if(count % 5 == 0) // Used for delay
            {
                controllers.ForEach(element => element.Update());
                mario.Update();
                goomba.Update();
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
                goomba.Draw(spriteBatch);
                

                base.Draw(gameTime);
            }

        }

    }
}
