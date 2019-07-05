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

namespace SuperMarioBros
{
    public enum ObjectState { Normal, NonCollidable, Destroy }
    public class MarioGame : Game
    {
        private readonly int windowWidth;
        private readonly int windowHeight;
        private bool pause = false;
        public ObjectsManager ObjectsManager { get; set; }
        public Camera Camera { get => marioCamera; }
        public ControllerMessager controller;
        private SpriteBatch spriteBatch;
        public CollisionManager collisionManager;
        public Camera marioCamera;
        public HeadsUp HeadsUps { get; set; }
        public IGameState State { get; set; }
        public bool FocusMario { get; set; }
        public MarioGame()
        {
            GraphicsDeviceManager graphics = new GraphicsDeviceManager(this);
            graphics.DeviceCreated += (o, e) =>
            {
                spriteBatch = new SpriteBatch((o as GraphicsDeviceManager).GraphicsDevice);
            };
            windowHeight = graphics.PreferredBackBufferHeight;
            windowWidth = graphics.PreferredBackBufferWidth;
            Content.RootDirectory = "Content";
            FocusMario = true;
        }

        public void ChangeToFlagPoleState()
        {
            State = new FlagPoleState(this);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }
        protected override void Initialize()
        {
            IsMouseVisible = true;
            State = new MenuState(this);
            SpriteFactory.Initialize(Content);
            marioCamera = new Camera(windowWidth);
            HeadsUps = new HeadsUp(this);
            ObjectFactory.Instance.ItemCollectedEvent += HeadsUps.CoinCollected;
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
            {
                pause = false;
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            State.Draw(gameTime, spriteBatch);
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
            ObjectsManager = new ObjectsManager(new ObjectLoader(), this, windowHeight);
           // ObjectsManager.LevelLoading();
            ObjectsManager.Initialize();
            marioCamera = new Camera(windowWidth);
            marioCamera.SetFocus(ObjectsManager.Mario);
            ObjectFactory.Instance.Initialize(this);
            //AudioFactory.Instance.Initialize(Content, "Content/sounds.xml", "Content/musics.xml");
            collisionManager = new CollisionManager(this);
            KeyBinding();
            

            //MediaPlayer.Play(AudioFactory.Instance.CreateSong("overworld"));

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
            HeadsUps.timerOverEvent += ObjectsManager.Mario.TimeOver;
        }

        public void ChangeToGameState()
        {
           State = new GameState(this);
        }

        public void KeyBinding()
        {
            IMario mario = ObjectsManager.Mario;
            controller = new ControllerMessager(mario, this);
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
    }
}
