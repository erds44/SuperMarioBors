using SuperMarioBros.Classes.Objects.BlockObjects;
using SuperMarioBros.Interfaces;
using SuperMarioBros.Interfaces.Object;

namespace SuperMarioBros
{
    class InputAction : IReceiver
    {
        private readonly IMario mario;
        private readonly MarioGame game;
        private readonly BlockObject blockObject;
        public InputAction(IMario mario)
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
            
        }
        public void SmallMario()
        {
            

        }
        public void FireMario()
        {
           
        }
        public void DeadMario()
        {
            
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

        public void Idle()
        {
            mario.Idle();
        }
    }
}
