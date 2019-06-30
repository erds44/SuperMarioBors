using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SuperMarioBros.Controllers;
using SuperMarioBros.GameCoreComponents;
using SuperMarioBros.HeadsUps;
using SuperMarioBros.Loading;
using SuperMarioBros.Managers;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.GameStates
{
    public class GameState : IGameState
    {
        private GraphicsDevice graphicsDevice;
        //private ContentManager contentManager;
        private HeadsUp headsUp;
        public GameState(GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.graphicsDevice = graphicsDevice;
           //this.contentManager = content;
            SpriteFactory.Initialize(content);
            headsUp = new HeadsUp(content);
            MarioGame.Instance.marioCamera = new Camera();
            InitializeGame();
            ObjectFactory.Instance.ItemCollectedEvent += headsUp.CoinCollected;
        }
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(sortMode: SpriteSortMode.FrontToBack, samplerState: SamplerState.PointClamp, transformMatrix: MarioGame.Instance.marioCamera.Transform);
            graphicsDevice.Clear(Color.CornflowerBlue);
            MarioGame.Instance.ObjectsManager.Draw(spriteBatch);
            headsUp.Draw(spriteBatch, MarioGame.Instance.Camera.LeftBound);
            spriteBatch.End();
        }

        public void InitializeGame()
        {
            MarioGame.Instance.ObjectsManager = new ObjectsManager(new ObjectLoader(), headsUp);
            MarioGame.Instance.ObjectsManager.LevelLoading();
            MarioGame.Instance.ObjectsManager.Initialize();
            ObjectFactory.Instance.Initialize();
            MarioGame.Instance.marioCamera.Reset();
            MarioGame.Instance.marioCamera.SetFocus(MarioGame.Instance.ObjectsManager.Mario);
            MarioGame.Instance.collisionManager = new CollisionManager();
            KeyBinding();

            MarioGame.Instance.ObjectsManager.Mario.DeathEvent += headsUp.OnMarioDeath;
            MarioGame.Instance.ObjectsManager.Mario.DeathEvent += headsUp.ResetTimer;
            MarioGame.Instance.ObjectsManager.Mario.PowerUpEvent += headsUp.PowerUpCollected;
            MarioGame.Instance.ObjectsManager.Mario.ExtraLifeEvent += headsUp.ExtraLife;
        }

        public void Update(GameTime gameTime)
        {
            MarioGame.Instance.controller.Update(gameTime);
            MarioGame.Instance.marioCamera.Update();
            MarioGame.Instance.ObjectsManager.Update(gameTime);
            MarioGame.Instance.collisionManager.Update();
            headsUp.Update(gameTime);
        }
        public void KeyBinding()
        {
            IMario mario = MarioGame.Instance.ObjectsManager.Mario;
            MarioGame.Instance.controller = new ControllerMessager(mario);
            IController keyboardController = new KeyboardController
                (MarioGame.Instance.controller,
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
            MarioGame.Instance.controller.AddController(keyboardController);
            IController JoyStickController = new JoyStickController(MarioGame.Instance.controller);
            MarioGame.Instance.controller.AddController(JoyStickController);
        }
    }
}
