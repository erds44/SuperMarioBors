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

namespace SuperMarioBros
{
    public enum ObjectState { Normal, NonCollidable, Destroy }
    public class MarioGame : Game
    {
        public readonly int WindowWidth;

        public readonly int WindowHeight;
        private bool pause = false;
        public ObjectsManager ObjectsManager { get; set; }
        public Camera Camera { get; private set; }
        public IController Controller { get; private set; }
        private SpriteBatch spriteBatch;
        public CollisionManager CollisionManager;
        public IMario Player => ObjectsManager.Mario;
        public HeadsUp HeadsUps { get; set; }
        public IGameState State { get; set; }
        public bool FocusMario { get; set; }
        private IMario mario;
        public bool IskeyboardController { get; set; }
        public MarioGame()
        {
            GraphicsDeviceManager graphics = new GraphicsDeviceManager(this);
            graphics.DeviceCreated += (o, e) =>
            {
                spriteBatch = new SpriteBatch((o as GraphicsDeviceManager).GraphicsDevice);
            };
            WindowHeight = graphics.PreferredBackBufferHeight;
            WindowWidth = graphics.PreferredBackBufferWidth;
            Content.RootDirectory = "Content";
            FocusMario = true;
            IskeyboardController = false;
        }

        public void ChangeToFlagPoleState()
        {
            State = new FlagPoleState(this);
        }
        protected override void Initialize()
        {
            IsMouseVisible = true;
            State = new MenuState(this);
            SpriteFactory.Initialize(Content);
            Camera = new Camera(WindowWidth);
            HeadsUps = new HeadsUp(this);
            ObjectFactory.Instance.ItemCollectedEvent += HeadsUps.CoinCollected;
            AudioFactory.Instance.Initialize(Content, "Content/sounds.xml", "Content/musics.xml", "Content/hurry.xml");
            base.Initialize();
        }
        protected override void Update(GameTime gameTime)
        {
            CheckPause();
            State.Update(gameTime);
            base.Update(gameTime);
        }

        private void CheckPause()
        {
            if (!pause && Keyboard.GetState().IsKeyDown(Keys.P))
            {
                pause = true;
                State.Pause();
            }
            else if (pause && Keyboard.GetState().IsKeyUp(Keys.P))
                pause = false;
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
        public void ChangeToGameOvertState()
        {
            State = new GameOverState(this);
        }
        public void ChangeToTeleportingState()
        {
            State = new TeleportingState(this);
        }
       
        public void InitializeGame()
        {
            ObjectsManager = new ObjectsManager(new ObjectLoader(), this);
           // ObjectsManager.LevelLoading();
            ObjectsManager.Initialize();
            Camera.Reset(ObjectsManager.Mario);
            //marioCamera.SetFocus(ObjectsManager.Mario);
            ObjectFactory.Instance.Initialize(this);
            CollisionManager = new CollisionManager(this);
            mario = ObjectsManager.Mario;
            if (IskeyboardController)
                InitializeKeyBoard();
            else
                InitializeGamePad();

            ObjectsManager.Mario.DeathEvent += HeadsUps.OnMarioDeath;
            ObjectsManager.Mario.DeathEvent += InitializeGame;
            ObjectsManager.Mario.SlidingEvent += HeadsUps.AddFlagScore;
            ObjectsManager.Mario.DeathEvent += HeadsUps.ResetTimer;
            ObjectsManager.Mario.PowerUpEvent += HeadsUps.PowerUpCollected;
            ObjectsManager.Mario.ExtraLifeEvent += HeadsUps.ExtraLife;
            ObjectsManager.Mario.ClearingScoresEvent += HeadsUps.ClearingScores;
            ObjectsManager.Mario.FocusMarioEvent += SetFocusMario;
            ObjectsManager.Mario.ChangeToGameStateEvent += ChangeToGameState;
            ObjectsManager.Mario.ChangeToTeleportStateEvent += ChangeToTeleportingState;
            ObjectsManager.Mario.IsFlagPoleStateEvent += IsFlagPoleState;
            ObjectsManager.Mario.SetCameraFocus += SetCameraFocus;
            ObjectsManager.Mario.ChangeToFlagPoleStateEvent += ChangeToFlagPoleState;
            HeadsUps.TimeOverEvent += ObjectsManager.Mario.TimeOver;
        }

        public void ChangeToGameState()
        {
           State = new GameState(this);
        }
        public void StartOver()
        {
            Initialize();
            InitializeGame();
            State = new MenuState(this);
        }
        public void SetFocusMario(bool focus)
        {
            FocusMario = focus;
        }
        public void SetCameraFocus(Vector2 position)
        {
            Camera.Update(position);
        }
        public bool IsFlagPoleState()
        {
            return State is FlagPoleState;
        }
        private void InitializeKeyBoard()
        {
            Controller = new KeyboardController(
                    (Keys.Q, new QuitCommand(this), new EmptyCommand(), false),
                    (Keys.R, new ResetCommand(this), new EmptyCommand(), false),
                    (Keys.Left, new LeftCommand(mario), new IdleCommand(mario), true),
                    (Keys.Down, new DownCommand(mario), new UpCommand(mario), true),
                    (Keys.Right, new RightCommand(mario), new IdleCommand(mario), true),
                    (Keys.Up, new UpCommand(mario), new KeyUpUpCommand(mario), true),
                    (Keys.X, new PowerCommand(mario), new KeyUpPowerCommand(mario), true)
                    );
        }

        private void InitializeGamePad()
        {
            Controller = new JoyStickController(mario,
                    (Buttons.A, new UpCommand(mario), new KeyUpUpCommand(mario), true),
                    (Buttons.RightTrigger, new PowerCommand(mario), new KeyUpPowerCommand(mario), false),
                    (Buttons.Y, new QuitCommand(this), new EmptyCommand(), false)
                );
        }
        public void SetKeyboardController()
        {
            IskeyboardController = true;
        }
    }
}
