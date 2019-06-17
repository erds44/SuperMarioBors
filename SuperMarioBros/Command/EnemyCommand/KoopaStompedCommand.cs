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
        public KoopaStompedCommand(IDynamic enemy)
        {
            this.enemy = (IEnemy)enemy;
        }
        public void Execute()
        {
            ObjectsManager.Instance.ChangeObject(enemy, new StompedKoopa(new Vector2(enemy.HitBox().X, enemy.HitBox().Y + enemy.HitBox().Height)));
        }
    }
}
