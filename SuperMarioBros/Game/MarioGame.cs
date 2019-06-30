using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Controllers;
using SuperMarioBros.GameCoreComponents;
using SuperMarioBros.Managers;
using SuperMarioBros.HeadsUps;
using SuperMarioBros.GameStates;

namespace SuperMarioBros
{
    public enum ObjectState { Normal, NonCollidable, Destroy }
    public sealed class MarioGame : Game
    {
        public int WindowWidth { get; private set; }
        public int WindowHeight { get; private set; }

        public ObjectsManager ObjectsManager { get; set; }
        public Camera Camera { get => marioCamera; }
        public ControllerMessager controller;
        private SpriteBatch spriteBatch;
        public CollisionManager collisionManager;
        public Camera marioCamera;
        public HeadsUp headsUp;
        public static MarioGame Instance { get; private set; }
        public IGameState State { get; private set; }
        private GraphicsDeviceManager graphics;
        public MarioGame()
        {
            Instance = this;
            graphics = new GraphicsDeviceManager(this);
            graphics.DeviceCreated += (o, e) =>
            {
                spriteBatch = new SpriteBatch((o as GraphicsDeviceManager).GraphicsDevice);
            };
            WindowHeight = graphics.PreferredBackBufferHeight;
            WindowWidth = graphics.PreferredBackBufferWidth;
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            //Things in this method only initialize once.
            State = new MenuState(graphics.GraphicsDevice, Content);
            base.Initialize();
        }
        protected override void Update(GameTime gameTime)
        {
            State.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            State.Draw(gameTime, spriteBatch);
            base.Draw(gameTime);
        }
        public void ChangeState(IGameState state)
        {
            State = state;
        }

    }
}
