namespace SuperMarioBros.Enemy
{
    public interface IEnemyState 
    {
        void ChangeDirection();
        void TakeDamage();
        void Stomped();
    }
}