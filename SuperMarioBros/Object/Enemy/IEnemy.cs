using SuperMarioBros.Sprites;

namespace SuperMarioBros.Enemy
{
    public interface IEnemy : IDynamic
    {
        IEnemyState State { get; set; }
        ISprite Sprite { get; set; }
        void Flip();
        void BumpUp();
    }
}
