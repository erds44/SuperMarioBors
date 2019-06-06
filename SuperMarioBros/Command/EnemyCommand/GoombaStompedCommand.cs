using SuperMarioBros.Goombas;
using SuperMarioBros.Object.Enemy;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class GoombaStompedCommand : ICommand
    {
        private readonly IEnemy enemy;
        private readonly int index;
        public GoombaStompedCommand(IEnemy enemy, int index)
        {
            this.enemy = enemy;
            this.index = index;
        }
        public void Execute()
        {
            ObjectsManager.Instance.DecorateObject(new StompedGoomba(enemy), index);
        }
    }
}
