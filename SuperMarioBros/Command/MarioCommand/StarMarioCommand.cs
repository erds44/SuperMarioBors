using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;

namespace SuperMarioBros.Commands
{
    class StarMarioCommand : ICommand
    {
        private  readonly IMario mario;
        private readonly int index; 
        public StarMarioCommand( IMario mario, int index)
        {
            this.mario = mario;
            this.index = index;
        }
        public void Execute()
        {
            if(mario is FlashingMario)
            {
                mario.Timer = 0;
                mario.Update();
                IMario newMario = ObjectsManager.Instance.Mario[index];
                ObjectsManager.Instance.DecorateMario(new StarMario(newMario, index), index);
            }
            else
            {
                ObjectsManager.Instance.DecorateMario(new StarMario(mario, index), index);
            }

        }
    }
}
