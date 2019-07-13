using SuperMarioBros.Blocks;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Stats;

namespace SuperMarioBros.Collisions
{
    public class EnemyBlockCollisionHandler : GeneralHandler
    {
        public static void KoopaBumped(IEnemy enemy, IBlock block, Direction direction)
        {
            enemy.Stomped();
            enemy.Flipped();
            enemy.ObjState = ObjectState.NonCollidable;
            StatsManager.Instance.Enemykilled(enemy.Position, enemy.Score);

        }
        public static void GoombaBumped(IEnemy enemy, IBlock block, Direction direction)
        {
            enemy.Flipped();
            enemy.ObjState = ObjectState.NonCollidable;
            StatsManager.Instance.Enemykilled(enemy.Position, enemy.Score);
        }
        
        public static void EnemyHorizontallyBounce(IEnemy enemy, IBlock block, Direction direction)
        {
            MoverHorizontallyBounce(enemy, block, direction);
            enemy.ChangeDirection();
        }
    }
}
