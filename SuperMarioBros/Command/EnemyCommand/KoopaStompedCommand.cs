using SuperMarioBros.Goombas;
using SuperMarioBros.Koopas;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class KoopaStompedCommand : ICommand
    {
        private readonly IEnemy enemy;
        public KoopaStompedCommand(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void Execute()
        {
            ObjectsManager.Instance.DecorateObject(enemy, new StompedKoopa(enemy));
        }
    }
}
