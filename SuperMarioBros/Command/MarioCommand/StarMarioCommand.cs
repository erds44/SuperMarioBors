using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class StarMarioCommand : ICommand
    {
        private  readonly IMario mario;
        public StarMarioCommand( IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            ObjectsManager.Instance.DecorateMario(new StarMario(mario));
        }
    }
}
