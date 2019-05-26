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
using SuperMarioBros.Class.Command;
using SuperMarioBros.Class.Object.BlockObject;
using SuperMarioBros.Interface.Object.BlockObject;

namespace SuperMarioBros
{
    public class MarioGame : Game
    {
        //private List<KeyboardController> controllers = new List<KeyboardController>();
        private KeyboardController controller;
        private SpriteBatch spriteBatch;
        private int count;
        private MarioObject mario;
        private List<IObject> objects;
        private IBlockObject brickBlock;
        private IBlockObject hiddenBlock;
        private IBlockObject questionBlock;
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
            SpriteFactory.Initialize(Content);
            InitializeObjectsAndKeys();
            base.Initialize();
        }
        protected override void Update(GameTime gameTime)
        {
            count++;
            if(count % 5 == 0) // Used for delay
            {
                //controllers.ForEach(element => element.Update());
                controller.Update();
                mario.Update();
                objects.ForEach(element => element.Update());
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
                objects.ForEach(element => element.Draw(spriteBatch));
                base.Draw(gameTime);
            }

        }
        private void KeyBinding(KeyboardController controller)
        {
            IReceiver marioReceiver = new InputAction(mario);
            IReceiver gameReceiver = new InputAction(this);
            IReceiver brickBlockReceiver = new InputAction(brickBlock);
            IReceiver hiddenBlockReceiver = new InputAction(hiddenBlock);
            IReceiver questionBlockReceiver = new InputAction(questionBlock);
            controller.Add(Keys.Q, new Quit(gameReceiver));
            controller.Add(Keys.A, new LeftCommand(marioReceiver));
            controller.Add(Keys.S, new DownCommand(marioReceiver));
            controller.Add(Keys.D, new RightCommand(marioReceiver));
            controller.Add(Keys.W, new UpCommand(marioReceiver));
            controller.Add(Keys.Y, new SmallMarioCommand(marioReceiver));
            controller.Add(Keys.U, new BigMarioCommand(marioReceiver));
            controller.Add(Keys.I, new FireMarioCommand(marioReceiver));
            controller.Add(Keys.O, new DieCommand(marioReceiver));
            controller.Add(Keys.R, new ResetCommand(gameReceiver));
            controller.Add(Keys.Z, new QuestionToUsedCommand(questionBlockReceiver));
            controller.Add(Keys.X, new BrickToDisappearCommand(brickBlockReceiver));
            controller.Add(Keys.C, new HiddenToUsedCommand(hiddenBlockReceiver));
        }
        public void InitializeObjectsAndKeys()
        {
            objects = new List<IObject>();
            mario = new MarioObject(new Vector2(400, 300), "SmallMario");
            brickBlock = new BrickBlockObject(new Vector2(150, 200));
            hiddenBlock = new HiddenBlockObject(new Vector2(200, 200));
            questionBlock = new QuestionBlockObject(new Vector2(100, 200));

            objects.Add(mario);
            objects.Add(brickBlock);
            objects.Add(hiddenBlock);
            objects.Add(questionBlock);
            objects.Add(new GoombaObject(new Vector2(100, 100)));
            controller = new KeyboardController();
            KeyBinding(controller);
        }

    }
}
