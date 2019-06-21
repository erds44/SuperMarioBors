using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Objects;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Controllers;
using SuperMarioBros.Marios;
using SuperMarioBros.Collisions;
using SuperMarioBros.GameCoreComponents;
using SuperMarioBros.LoadingTest;
using SuperMarioBros.Managers;

namespace SuperMarioBros
{
    // [ComVisible(false)]
    public class MarioGame : Game
    {
        public static int WindowWidth { get; private set; }
        public static int WindowHeight { get; private set; }
        private ControllerMessager controller;
        private SpriteBatch spriteBatch;
        private CollisionManager collisionManager;
        private Camera marioCamera;
        public MarioGame()
        {
            var graphicsDeviceManager = new GraphicsDeviceManager(this);
            graphicsDeviceManager.DeviceCreated += (o, e) =>
            {
                spriteBatch = new SpriteBatch((o as GraphicsDeviceManager).GraphicsDevice);
            };
            WindowHeight = graphicsDeviceManager.PreferredBackBufferHeight;
            WindowWidth = graphicsDeviceManager.PreferredBackBufferWidth;
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            SpriteFactory.Initialize(Content);
            marioCamera = Camera.Instance;
            InitializeGameComponents();
            //
            XMLProcessor.LoadObjects();
            base.Initialize();
        }
        protected override void Update(GameTime gameTime)
        {
            controller.Update();
            ObjectsManager.Instance.Update(gameTime);
            collisionManager.HandleCollision();
            marioCamera.Follow();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack,samplerState: SamplerState.PointClamp, transformMatrix:marioCamera.Transform);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            ObjectsManager.Instance.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public void KeyBinding()
        {
            IMario mario = ObjectsManager.Instance.MarioObject();
            controller = new ControllerMessager(this, mario);
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
                    (Keys.Up, ControllerMessager.UPMOVE),
                    (Keys.X, ControllerMessager.POWER)
                );
            controller.AddController(keyboardController);
            IController JoyStickController = new JoyStickController(controller);
            controller.AddController(JoyStickController);
        }

        public void InitializeGameComponents()
        {
            ObjectLoading.LevelLoading(Content, "PartialLevelOne");
            ObjectSizeManager.LoadItemSize(Content, "SizeLoading");
            ObjectSizeManager.LoadMarioSize(Content, "MarioSizeLoading");
            ObjectsManager.Instance.Initialize();
            marioCamera.Reset();
            marioCamera.SetFocus(ObjectsManager.Instance.MarioObject());
            collisionManager = new CollisionManager();
            KeyBinding();
        }

    }
}
