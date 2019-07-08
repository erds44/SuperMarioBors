using SuperMarioBros.Blocks;
using SuperMarioBros.Objects.Enemy;

namespace SuperMarioBros.Collisions
{
    public class EnemyBlockCollisionHandler : GeneralHandler
    {
        public static void KoopaBumped(IEnemy enemy, IBlock block, Direction direction)
        {
            enemy.Stomped(1);
            enemy.Flipped(1);
            enemy.ObjState = ObjectState.NonCollidable;
        }
        public static void GoombaBumped(IEnemy enemy, IBlock block, Direction direction)
        {
            enemy.Flipped(1);
            enemy.ObjState = ObjectState.NonCollidable;
        }
        public static void EnemyHorizontallyBounce(IEnemy enemy, IBlock block, Direction direction)
        {
            MoverHorizontallyBounce(enemy, block, direction);
            enemy.ChangeDirection();
        }
    }
}
