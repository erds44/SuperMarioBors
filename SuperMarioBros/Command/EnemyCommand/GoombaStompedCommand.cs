using SuperMarioBros.Goombas;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Commands
{
    class GoombaStompedCommand : ICommand
    {
        private readonly IEnemy enemy;
        public GoombaStompedCommand(IEnemy enemy)
        {
            this.enemy = enemy;
        }
        public void Execute()
        {
            ObjectsManager.Instance.DecorateObject(enemy , new StompedGoomba(enemy));
        }
    }
}
