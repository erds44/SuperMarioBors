using SuperMarioBros.Classes.Objects.BlockObjects;
using SuperMarioBros.Classes.Objects.MarioObjects;
using SuperMarioBros.Interfaces;

namespace SuperMarioBros
{
    class InputAction : IReceiver
    {
        private readonly MarioObject mario;
        private readonly MarioGame game;
        private readonly BlockObject blockObject;
        public InputAction(MarioObject mario)
        {
            this.mario = mario;
        }
        public InputAction(MarioGame game)
        {
            this.game = game;
        }
        public InputAction(BlockObject blockObject)
        {
            this.blockObject = blockObject;
        }
        public void Left() 
        {
            mario.Left();
        }
        public void Right()
        {
            mario.Right();
        }

        public void Up()
        {
            mario.Up();
        }
        public void Down()
        {
            mario.Down();
        }
        public void BigMario()
        {
            mario.ToBig();
        }
        public void SmallMario()
        {
            mario.ToSmall();

        }
        public void FireMario()
        {
            mario.ToFire();
        }
        public void DeadMario()
        {
            mario.Die();
        }
        public void Reset()
        {
            game.InitializeObjectsAndKeys();
            game.KeyBinding();
        }
        public void Quit()
        {
            game.Exit();
        }

        public void QuestionBlockToUsedBlock()
        {
            blockObject.Used();
        }

        public void HiddenBlockToUsedBlock()
        {
            blockObject.Used();
        }

        public void BrickBlockDisappear()
        {
            blockObject.Disappear();
        }
    }
}
