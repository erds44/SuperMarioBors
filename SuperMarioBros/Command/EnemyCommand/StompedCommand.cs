using SuperMarioBros.Marios;
using SuperMarioBros.Object.Enemy;

namespace SuperMarioBros.Commands
{
    class StompedCommand : ICommand
    {
        private readonly IEnemy enemy;
        public StompedCommand(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void Execute()
        {
            enemy.BeStomped();
        }
    }
}
