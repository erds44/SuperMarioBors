using SuperMarioBros.Marios;
using SuperMarioBros.Objects.Enemy;

namespace SuperMarioBros.Collisions
{
    public class MarioEnemyCollisionHandler : GeneralHandler
    {
       public static void NormalMarioVsEnemyTopSideCollision(IMario mario, IEnemy enemy)
        {
            Bump(mario);
            enemy.Stomped(mario.EnemyKillStreakCounter);
            mario.EnemyKillStreakCounter++;
        }
        public static void StarMarioVsEnemy(IMario mario, IEnemy enemy)
        {
            enemy.Flipped(mario.EnemyKillStreakCounter);
            enemy.ObjState = ObjectState.NonCollidable;
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
                if (mario.HitBox().Center.X <= koopa.HitBox().Center.X)
                    koopa.MoveRight();
                else
                    koopa.MoveLeft();
                koopa.DealDemage = true;
            }
            Bump(mario);
            ResolveOverlap(mario, koopa, Direction.top);
        }
        public static void NormalMarioVsShelledMovingKoopaTopSideCollision(IMario mario, IEnemy enemy)
        {
            Koopa koopa = (Koopa)enemy;
            if (koopa.DealDemage)
            {
                koopa.Flipped(mario.EnemyKillStreakCounter);
                mario.EnemyKillStreakCounter++;
                koopa.ObjState = ObjectState.NonCollidable;
            }
            ResolveOverlap(mario, koopa, Direction.top);
        }

        public static void MoveShelledIdleKoopa(IMario mario, IEnemy enemy)
        {
            Koopa koopa = (Koopa)enemy;
            if(mario.HitBox().Center.X <= koopa.HitBox().Center.X)
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
                mario.TakeDamage();
        }
    }
}
