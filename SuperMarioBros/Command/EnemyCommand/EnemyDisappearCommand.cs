using SuperMarioBros.Goombas;
using SuperMarioBros.Koopas;
using SuperMarioBros.Object.Enemy;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class EnemyDisappearCommand : ICommand
    {
        private readonly IEnemy enemy;
        private readonly int index;
        public EnemyDisappearCommand(IEnemy enemy, int index)
        {
            this.enemy = enemy;
            this.index = index;
        }
        public void Execute()
        {
            ObjectsManager.Instance.Remove(enemy, index);
        }
    }
}
