using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Objects;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Commands;
using SuperMarioBros.Controllers;
using SuperMarioBros.Marios;
using SuperMarioBros.Collisions;
using System;

namespace SuperMarioBros
{
    // [ComVisible(false)]
    public class MarioGame : Game
    {
        private IController controller;
        private SpriteBatch spriteBatch;
        private CollisionManager collisionManager;
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
            SpriteFactory.Initialize(Content);
            InitializeObjects();
            base.Initialize();
        }
        protected override void Update(GameTime gameTime)
        {
            controller.Update();
            ObjectsManager.Instance.Update();
            collisionManager.HandleCollision();
            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            GraphicsDevice.Clear(Color.CornflowerBlue);
            ObjectsManager.Instance.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public void KeyBinding()
        {
            IMario mario = ObjectsManager.Instance.MarioObject()[0];
            controller = new KeyboardController
                (
                    (Keys.Q, new Quit(this)),
                    (Keys.A, new LeftCommand(mario)),
                    (Keys.S, new DownCommand(mario)),
                    (Keys.D, new RightCommand(mario)),
                    (Keys.W, new UpCommand(mario)),
                    (Keys.R, new ResetCommand(this)),
                    (Keys.Left, new LeftCommand(mario)),
                    (Keys.Down, new DownCommand(mario)),
                    (Keys.Right, new RightCommand(mario)),
                    (Keys.Up, new UpCommand(mario))
              
                );
            controller.SetIdle(new IdleCommand(mario));
        }

        public void InitializeObjects()
        {
           
            ObjectLoading.LevelLoading(Content, @"PartialLevelOne");
            ObjectSizeManager.LoadItemSize(Content, @"SizeLoading");
            ObjectSizeManager.LoadMarioSize(Content, @"MarioSizeLoading");
            ObjectsManager.Instance.Initialize();
            collisionManager = new CollisionManager();
            KeyBinding();
        }

    }
}
