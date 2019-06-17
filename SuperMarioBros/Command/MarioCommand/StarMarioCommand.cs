using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class StarMarioCommand : ICommand
    {
        private  readonly IMario mario;
        public StarMarioCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            ObjectsManager.Instance.StarMario(mario);      
        }
    }
}
