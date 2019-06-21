using SuperMarioBros.Sprites;

namespace SuperMarioBros.Objects.Enemy
{
    public interface IEnemy : IDynamic
    {
        IEnemyMovementState State { get; set; }
        ISprite Sprite { get; set; }
        void Flip();
        void BumpUp();
    }
}
