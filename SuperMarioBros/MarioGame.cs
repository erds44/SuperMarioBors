using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Controllers;
using SuperMarioBros.Cameras;
using SuperMarioBros.Managers;
using SuperMarioBros.HeadsUps;
using SuperMarioBros.GameStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Loading;
using SuperMarioBros.Marios;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Commands;
using Buttons = Microsoft.Xna.Framework.Input.Buttons;
using SuperMarioBros.Stats;
using SuperMarioBros.Utility;

namespace SuperMarioBros
{
    public enum ObjectState { Normal, NonCollidable, Destroy }
    public class MarioGame : Game
    {
        public readonly int WindowWidth;
        public readonly int WindowHeight;
        public float CameraLeftBound { get => Camera.LeftBound; }
        public float CameraUpperBound { get => Camera.UpperBound; }
        public float CameraRightBound { get => Camera.RightBound; }
        public ObjectsManager ObjectsManager { get; private set; }
        public Camera Camera { get; private set; }
        public IController Controller { get; set; }
        private SpriteBatch spriteBatch;
        public CollisionManager CollisionManager;
        public IMario Player => ObjectsManager.Mario;
        public IGameState State { get; set; }
        public bool IskeyboardController { get; private set; } = true;
        public HUD Hud { get; private set; }
        public MarioGame()
        {
            GraphicsDeviceManager graphics = new GraphicsDeviceManager(this);
            graphics.DeviceCreated += (o, e) =>
            {
                spriteBatch = new SpriteBatch((o as GraphicsDeviceManager).GraphicsDevice);
            };
            WindowHeight = graphics.PreferredBackBufferHeight;
            WindowWidth = graphics.PreferredBackBufferWidth;
            Content.RootDirectory = StringConsts.Content;
        }

        protected override void LoadContent()
        {
            AudioFactory.Instance.Load(Content, StringConsts.SoundsFile, StringConsts.MusicsFile, StringConsts.HurrysFile);
            base.LoadContent();
        }

        protected override void Initialize()
        {
            SpriteFactory.Initialize(Content); 
            Camera = new Camera(WindowWidth);
            StatsManager.Instance.Initialize();
            Hud = new HUD(this);
            ObjectsManager = new ObjectsManager(new ObjectLoader(), this);
            ObjectsManager.Initialize();
            ObjectFactory.Instance.Initialize(this);
            CollisionManager = new CollisionManager(this);
            State = new MenuState(this);
            Camera.SetFocus(Player);
            EventBinding();
            base.Initialize();
        }
        protected override void Update(GameTime gameTime)
        {
            State.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            State.Draw(spriteBatch);
            base.Draw(gameTime);
        }
        public void ChangeToPlayerStatusState()
        {
            State = new PlayerStatusState(this);
        }
        public void ChangeToTeleportingState(Vector2 Position)
        {
            State = new TeleportingState(this, Position);
        }
        public void ChangeToFlagPoleState()
        {
            State = new FlagPoleState(this);
        }

        public void ResetGame()
        {
            ObjectsManager = new ObjectsManager(new ObjectLoader(), this);
            ObjectsManager.Initialize();
            State.Reset();
            Camera.Reset(Player);
            ObjectFactory.Instance.Initialize(this);
            CollisionManager = new CollisionManager(this);
            if (Controller is KeyboardController) InitializeKeyBoard();
            else InitializeGamePad();
            StatsManager.Instance.ResetTimer();
            EventBinding();
        }

        public void EventBinding()
        {
            Player.ChangeToTeleportStateEvent += ChangeToTeleportingState;
            Player.ChangeToFlagPoleStateEvent += ChangeToFlagPoleState;
        }

        public void StartOver()
        {
            Initialize();
        }
        public void SetFocus(IObject obj)
        {
            Camera.SetFocus(obj);
        }
        public void SetCameraFocus(Vector2 position)
        {
            Camera.Update(position);
        }
        public bool IsFlagPoleState()
        {
            return State is FlagPoleState;
        }
        public void InitializeKeyBoard()
        {
            Controller = new KeyboardController(
                    (Keys.Q, new QuitCommand(this), new EmptyCommand(), false),
                    (Keys.R, new ResetCommand(this), new EmptyCommand(), false),
                    (Keys.Left, new LeftCommand(Player), new IdleCommand(Player), true),
                    (Keys.Down, new DownCommand(Player), new UpPressedCommand(Player), true),
                    (Keys.Right, new RightCommand(Player), new IdleCommand(Player), true),
                    (Keys.Up, new UpPressedCommand(Player), new UpReleasedCommand(Player), true),
                    (Keys.X, new PowerPressedCommand(Player), new PowerReleasedCommand(Player), false),
                    (Keys.P, new PauseCommand(this), new EmptyCommand(), false)
                    );
        }

        public void InitializeGamePad()
        {
            Controller = new JoyStickController(Player,
                    (Buttons.A, new UpPressedCommand(Player), new UpReleasedCommand(Player), true),
                    (Buttons.RightTrigger, new PowerPressedCommand(Player), new PowerReleasedCommand(Player), false),
                    (Buttons.Y, new QuitCommand(this), new EmptyCommand(), false),
                    (Buttons.RightShoulder, new PauseCommand(this), new EmptyCommand(), false)
                );
        }
        public void DisableController()
        {
            Controller?.DisableController();
        }
        public void EnableController()
        {
            Controller?.EnableController();
        }
        public void Pause()
        {
            State.Pause();
        }
        public void SetControllerAsGamePad()
        {
            IskeyboardController = false;
        }
    }
}
