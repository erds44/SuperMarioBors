namespace SuperMarioBros.Object.Enemy
{
    public interface IEnemyState 
    {
        void ChangeDirection();
        void BeStomped();
        void BeFlipped();
    }
}
