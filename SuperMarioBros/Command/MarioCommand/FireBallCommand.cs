using SuperMarioBros.Marios;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class FireBallCommand : ICommand
    {
        private readonly IMario mario;
        public FireBallCommand(IDynamic mario)
        {
            this.mario = (IMario)mario;
        }
        public void Execute()
        {
            mario.FireBall();
        }
    }
}
