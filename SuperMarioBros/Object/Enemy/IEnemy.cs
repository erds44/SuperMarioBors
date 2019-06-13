using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Objects.Enemy
{
    public interface IEnemy : IObject, IEnemyMovementState
    {
        IEnemyMovementState State { get; set; }
        ISprite Sprite { get; set; }
    }
}
