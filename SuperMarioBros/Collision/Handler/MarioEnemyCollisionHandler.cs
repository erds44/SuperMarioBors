using SuperMarioBros.AudioFactories;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Stats;

namespace SuperMarioBros.Collisions
{
    public class MarioEnemyCollisionHandler : GeneralHandler
    {
        public static void NormalMarioVsEnemyTopSideCollision(IMario mario, IEnemy enemy)
        {
            Bump(mario);
            enemy.Stomped();
            mario.EnemyKillStreakCounter++;
            StatsManager.Instance.Enemykilled(enemy.Position, enemy.Score, mario.EnemyKillStreakCounter);
            AudioFactory.Instance.CreateSound("stomp").Play();
        }
        public static void StarMarioVsEnemy(IMario mario, IEnemy enemy)
        {
            enemy.Flipped();
            enemy.ObjState = ObjectState.NonCollidable;
            StatsManager.Instance.Enemykilled(enemy.Position, enemy.Score, mario.EnemyKillStreakCounter);
            AudioFactory.Instance.CreateSound("stomp").Play();
        }
        public static void NormalMarioTakeDamage(IMario mario, IEnemy enemy)
        {
            mario.TakeDamage();
        }
        public static void NormalMarioVsShelledIdleKoopaTopSideCollision(IMario mario, IEnemy enemy)
        {
            Koopa koopa = (Koopa)enemy;
            if (!koopa.DealDemage)
            {
                if (mario.HitBox.Center.X <= koopa.EnemyHitBox().Center.X)
                    koopa.MoveRight();
                else
                    koopa.MoveLeft();
                koopa.DealDemage = true;
                StatsManager.Instance.Enemykilled(koopa.Position, koopa.Score, mario.EnemyKillStreakCounter);
            }
            Bump(mario);
            ResolveOverlap(mario, koopa, Direction.top);
        }
        public static void NormalMarioVsShelledMovingKoopaTopSideCollision(IMario mario, IEnemy enemy)
        {
            Koopa koopa = (Koopa)enemy;
            if (koopa.DealDemage)
            {
                koopa.Flipped();
                mario.EnemyKillStreakCounter++;
                koopa.ObjState = ObjectState.NonCollidable;
                StatsManager.Instance.Enemykilled(koopa.Position, koopa.Score, mario.EnemyKillStreakCounter);
                AudioFactory.Instance.CreateSound("stomp").Play();
            }
            ResolveOverlap(mario, koopa, Direction.top);
        }

        public static void MoveShelledIdleKoopa(IMario mario, IEnemy enemy)
        {
            Koopa koopa = (Koopa)enemy;
            if(mario.HitBox.Center.X <= koopa.EnemyHitBox().Center.X)
            {
                koopa.MoveRight();
                ResolveOverlap(mario, koopa, Direction.left);
            }
            else
            {
                koopa.MoveLeft();
                ResolveOverlap(mario, koopa, Direction.right);
            }
        }

        public static void NormalMarioVsShelledMovingKoopaLeftOrRightCollision(IMario mario, IEnemy enemy)
        {
            Koopa koopa = (Koopa)enemy;
            if (!koopa.DealDemage)
            {
                mario.TakeDamage();
            }
        }
    }
}
