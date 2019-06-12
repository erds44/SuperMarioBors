using SuperMarioBros.Goombas;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Objects;
using Microsoft.Xna.Framework;

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
            ObjectsManager.Instance.ChangeEnemy(enemy , new StompedGoomba(new Point(enemy.HitBox().X, enemy.HitBox().Y + enemy.HitBox().Height)));
        }
    }
}
