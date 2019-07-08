using SuperMarioBros.Objects.Enemy;

namespace SuperMarioBros.Collisions
{
    public class EnemyEnemyCollisionHandler : GeneralHandler
    {
        public static void MoverStompsTarget(IEnemy mover, IEnemy koopa, Direction direction)
        {
            koopa.Stomped(mover.EnemyKillStreakCounter);
            koopa.EnemyKillStreakCounter++;
            Bump(mover);
            ResolveOverlap(mover, koopa, direction);
        }

        public static void EnemyVsShelledIdleKoopaTopCollision(IEnemy mover, IEnemy target, Direction direction)
        {
            Koopa koopa = (Koopa)target;
            if (!koopa.DealDemage)
            {
                    if (mover.HitBox().Center.X <= koopa.HitBox().Center.X)
                        koopa.MoveRight();
                    else
                        koopa.MoveLeft();
                    koopa.DealDemage = true;
            }
            ResolveOverlap(mover, koopa, direction);
        }

        public static void EnemyVsShelledMovingKoopaTopCollision(IEnemy mover, IEnemy target, Direction direction)
        {
            Koopa koopa = (Koopa)target;
            if (!koopa.DealDemage)
            {
                koopa.Flipped(mover.EnemyKillStreakCounter);
                koopa.EnemyKillStreakCounter++;
                koopa.ObjState = ObjectState.NonCollidable;
            }
            ResolveOverlap(mover, koopa, direction);
        }

        public static void EnemyChangeDirection(IEnemy mover, IEnemy target, Direction direction)
        {
            mover.ChangeDirection();
            target.ChangeDirection();
            ResolveOverlap(mover, target, direction);
        }
        public static void MoverChangeDirection(IEnemy mover, IEnemy target, Direction direction)
        {
            mover.ChangeDirection();
            ResolveOverlap(mover, target, direction);
        }

        public static void MoverFlipped(IEnemy mover, IEnemy target, Direction direction)
        {
            Koopa koopa = (Koopa)target;
            mover.Flipped(koopa.EnemyKillStreakCounter);
            koopa.EnemyKillStreakCounter++;
            mover.ObjState = ObjectState.NonCollidable;
        }

        public static void TargetStompsMover(IEnemy mover, IEnemy target, Direction direction)
        {
            mover.Stomped(target.EnemyKillStreakCounter);
            target.EnemyKillStreakCounter++;
            Bump(target);
            ResolveOverlap(mover, target, direction);
        }
    }
}
