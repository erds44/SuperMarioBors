using SuperMarioBros.Goombas;
using SuperMarioBros.Koopas;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Objects;
using Microsoft.Xna.Framework;

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
            ObjectsManager.Instance.ChangeEnemy(enemy, new StompedKoopa(new Point(enemy.HitBox().X, enemy.HitBox().Y + enemy.HitBox().Height)));
        }
    }
}
