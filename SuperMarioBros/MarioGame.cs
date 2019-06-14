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
using SuperMarioBros.Controller;

namespace SuperMarioBros
{
    // [ComVisible(false)]
    public class MarioGame : Game
    {
        private ControllerMessager controller;
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
            controller = new ControllerMessager(this, mario, new IdleCommand(mario));
            IController keyboardController = new KeyboardController
                (controller,
                    (Keys.Q, ControllerMessager.QUITGAME),
                    (Keys.A, ControllerMessager.LEFTMOVE),
                    (Keys.S, ControllerMessager.DOWNMOVE),
                    (Keys.D, ControllerMessager.RIGHTMOVE),
                    (Keys.W, ControllerMessager.UPMOVE),
                    (Keys.R, ControllerMessager.RESETGAME),
                    (Keys.Left, ControllerMessager.LEFTMOVE),
                    (Keys.Down, ControllerMessager.DOWNMOVE),
                    (Keys.Right, ControllerMessager.RIGHTMOVE),
                    (Keys.Up, ControllerMessager.UPMOVE)
                );
            controller.AddController(keyboardController);
            //IController GamePadController = new GamePadController();
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
