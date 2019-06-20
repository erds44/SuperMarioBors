using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Enemy
{
    public interface IEnemy : IDynamic
    {
        IEnemyState State { get; set; }
        ISprite Sprite { get; set; }

        void TakeDamage();

        void Flip();
    }
}
