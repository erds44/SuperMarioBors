using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Controllers;
using SuperMarioBros.GameCoreComponents;
using SuperMarioBros.Managers;
using SuperMarioBros.Loading;
using SuperMarioBros.Marios;
using SuperMarioBros.Object;

namespace SuperMarioBros
{
    public enum ObjectState { Normal, NonCollidable, Destroy }
    public sealed class MarioGame : Game
    {
        public int WindowWidth { get; private set; }
        public int WindowHeight { get; private set; }
        public int LevelLength { get; private set; }
        public ObjectsManager ObjectsManager { get; private set; }
        public Camera Camera { get => marioCamera; }
        public CollisionManager CollisionManager { get; private set; }
        private ControllerMessager controller;
        private SpriteBatch spriteBatch;
        private CollisionManager collisionManager;
        private Camera marioCamera;
        public static MarioGame Instance { get; private set; }
        public MarioGame()
        {
            Instance = this;
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
            //Things in this method only initialize once.
            SpriteFactory.Initialize(Content);
            marioCamera = new Camera();
            InitializeGame();
            base.Initialize();
        }
        protected override void Update(GameTime gameTime)
        {
            controller.Update(gameTime);
            marioCamera.Update();
            ObjectsManager.Update(gameTime);
            collisionManager.Update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack,samplerState: SamplerState.PointClamp, transformMatrix:marioCamera.Transform);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            ObjectsManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public void KeyBinding()
        {
            IMario mario = ObjectsManager.Mario;
            controller = new ControllerMessager(this, mario);
            IController keyboardController = new KeyboardController
                (controller,
                    (Keys.Q, ControllerMessager.QUITGAME),
                    (Keys.A, ControllerMessager.LEFTMOVE),
                    (Keys.S, ControllerMessager.DOWNMOVE),
                    (Keys.D, ControllerMessager.RIGHTMOVE),
                    (Keys.W, ControllerMessager.UPMOVE),
                    (Keys.Z, ControllerMessager.UPMOVE),
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

        public void InitializeGame()
        {
            ObjectsManager = new ObjectsManager(new ObjectLoader(this));
            ObjectFactory.Instance.Initialize();
            ObjectsManager.LevelLoading(Content, "PartialLevelOne");
            SizeManager.LoadItemSize(Content, "SizeLoading");
            SizeManager.LoadMarioSize(Content, "MarioSizeLoading");

            ObjectsManager.Initialize();

            marioCamera.Reset();
            marioCamera.SetFocus(ObjectsManager.Mario);
            collisionManager = new CollisionManager();
            KeyBinding();
        }

    }
}
