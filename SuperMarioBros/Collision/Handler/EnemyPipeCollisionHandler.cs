using SuperMarioBros.Blocks;
using SuperMarioBros.Object.Pipes;
using SuperMarioBros.Objects.Enemy;

namespace SuperMarioBros.Collisions
{
    public class EnemyPipeCollisionHandler : GeneralHandler
    {
       public static void EnemyHorizontalBounce(IEnemy enemy, IPipe pipe, Direction direction)
        {
            enemy.ChangeDirection();
            ResolveOverlap(enemy, pipe, direction);
        }
    }
}
