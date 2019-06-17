using SuperMarioBros.Goombas;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Objects;
using Microsoft.Xna.Framework;

namespace SuperMarioBros.Commands
{
    class GoombaStompedCommand : ICommand
    {
        private readonly IEnemy enemy;
        public GoombaStompedCommand(IDynamic enemy)
        {
            this.enemy =(IEnemy) enemy;
        }
        public void Execute()
        {
            ObjectsManager.Instance.ChangeObject(enemy , new StompedGoomba(new Vector2(enemy.HitBox().X, enemy.HitBox().Y + enemy.HitBox().Height)));
        }
    }
}
