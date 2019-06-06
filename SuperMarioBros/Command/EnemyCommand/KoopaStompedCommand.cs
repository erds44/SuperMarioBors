using SuperMarioBros.Goombas;
using SuperMarioBros.Koopas;
using SuperMarioBros.Object.Enemy;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class KoopaStompedCommand : ICommand
    {
        private readonly IEnemy enemy;
        private readonly int index;
        public KoopaStompedCommand(IEnemy enemy, int index)
        {
            this.enemy = enemy;
            this.index = index;
        }
        public void Execute()
        {
            ObjectsManager.Instance.DecorateObject(new StompedKoopa(enemy), index);
        }
    }
}
