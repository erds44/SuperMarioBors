using SuperMarioBros.AudioFactories;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Stats;
using static SuperMarioBros.Utility.StringConsts;

namespace SuperMarioBros.Collisions
{
    public class EnemyEnemyCollisionHandler : GeneralHandler
    {
        public static void MoverStompsTarget(IEnemy mover, IEnemy koopa, Direction direction)
        {
            koopa.Stomped();
            mover.EnemyKillStreakCounter++;
            BumpUp(mover);
            ResolveOverlap(mover, koopa, direction);
            StatsManager.Instance.Enemykilled(koopa.Position, koopa.Score, mover.EnemyKillStreakCounter);
            AudioFactory.Instance.CreateSound(Stomp).Play();
        }

        public static void EnemyVsShelledIdleKoopaTopCollision(IEnemy mover, IEnemy target, Direction direction)
        {
            Koopa koopa = (Koopa)target;
            if (!koopa.DealDemage)
            {
                    if (mover.HitBox.Center.X <= koopa.EnemyHitBox().Center.X)
                        koopa.MoveRight();
                    else
                        koopa.MoveLeft();
                    koopa.DealDemage = true;
                mover.EnemyKillStreakCounter++;
                StatsManager.Instance.Enemykilled(koopa.Position, koopa.Score, mover.EnemyKillStreakCounter);
            }
            ResolveOverlap(mover, koopa, direction);
        }

        public static void EnemyVsShelledMovingKoopaTopCollision(IEnemy mover, IEnemy target, Direction direction)
        {
            Koopa koopa = (Koopa)target;
            if (!koopa.DealDemage)
            {
                koopa.Flipped();
                koopa.EnemyKillStreakCounter++;
                koopa.ObjState = ObjectState.NonCollidable;
                StatsManager.Instance.Enemykilled(koopa.Position, koopa.Score, mover.EnemyKillStreakCounter);
                AudioFactory.Instance.CreateSound(Stomp).Play();
            }
            ResolveOverlap(mover, koopa, direction);
        }

        public static void EnemyChangeDirection(IEnemy mover, IEnemy target, Direction direction)
        {
            ResolveOverlap(mover, target, direction);
            mover.ChangeDirection();
            target.ChangeDirection();
        }
        public static void MoverChangeDirection(IEnemy mover, IEnemy target, Direction direction)
        {
            mover.ChangeDirection();
            ResolveOverlap(mover, target, direction);
        }

        public static void MoverFlipped(IEnemy mover, IEnemy target, Direction direction)
        {
            Koopa koopa = (Koopa)target;
            mover.Flipped();
            koopa.EnemyKillStreakCounter++;
            mover.ObjState = ObjectState.NonCollidable;
            StatsManager.Instance.Enemykilled(mover.Position, mover.Score, koopa.EnemyKillStreakCounter);
            AudioFactory.Instance.CreateSound(Stomp).Play();
        }

        public static void TargetStompsMover(IEnemy mover, IEnemy target, Direction direction)
        {
            mover.Stomped();
            target.EnemyKillStreakCounter++;
            BumpUp(target);
            ResolveOverlap(mover, target, direction);
            StatsManager.Instance.Enemykilled(mover.Position, mover.Score, target.EnemyKillStreakCounter);
            AudioFactory.Instance.CreateSound(Stomp).Play();
        }
    }
}
