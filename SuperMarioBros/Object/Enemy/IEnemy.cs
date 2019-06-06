using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Objects.Enemy
{
    public interface IEnemy : IObject, IEnemyMovementState
    {
        void ChangeState(IEnemyMovementState enemyMovementState);
        void ChangeSprite(ISprite sprite);
    }
}
