using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class StarMarioCommand : ICommand
    {
        private  IMario mario;
        public StarMarioCommand( IMario mario)
        {
            this.mario = mario;
        }
        public void Execute()
        {
            mario = new StarMario(mario);
            mario.TakeDamage();
            ObjectsManager.Instance.DecorateMario(mario);
        }
    }
}
