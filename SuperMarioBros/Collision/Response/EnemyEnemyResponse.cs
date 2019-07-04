using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class EnemyEnemyResponse : GeneralResponse
    {
        private readonly IEnemy enemy1;
        private readonly IEnemy enemy2;
        private readonly Direction direction;
        private delegate void EnemyEnemyHandler(IEnemy enemy1, IEnemy enemy2, Direction direction);

        public EnemyEnemyResponse(IObject enemy1, IObject enemy2, Direction direction)
        {
            this.enemy1 = (IEnemy)enemy1;
            this.enemy2 = (IEnemy)enemy2;
            this.direction = direction;
        }
        public override void HandleCollision()
        {
            if (handlerDictionary.TryGetValue((enemy1.GetType(), enemy2.GetType(), direction), out var handle1))
                handle1(enemy1, enemy2, direction);
            else if (handlerDictionary.TryGetValue((enemy2.GetType(), enemy1.GetType(), direction), out var handle2))
                handle2(enemy2, enemy1, ReverseDirection(direction));
        }
        private readonly Dictionary<(Type, Type, Direction), EnemyEnemyHandler> handlerDictionary = new Dictionary<(Type, Type, Direction), EnemyEnemyHandler>
        {
            { (typeof(Goomba), typeof(Koopa), Direction.top), EnemyVSKoopaTopCollision },
            { (typeof(Goomba), typeof(Koopa), Direction.left), EnemyKoopaLeftOrRightCollision },
            { (typeof(Goomba), typeof(Koopa), Direction.right), EnemyKoopaLeftOrRightCollision },
            { (typeof(Goomba),  typeof(Goomba), Direction.right), GeneralEnemyLeftOrRightCollision},
            { (typeof(Goomba),  typeof(Goomba), Direction.left), GeneralEnemyLeftOrRightCollision},
            { (typeof(Goomba),  typeof(Goomba), Direction.top), GeneralEnemyTopCollision},

            { (typeof(Koopa),  typeof(Goomba), Direction.top), GeneralEnemyTopCollision },
            { (typeof(Koopa),  typeof(Koopa), Direction.left), EnemyKoopaLeftOrRightCollision},
            { (typeof(Koopa),  typeof(Koopa), Direction.right), EnemyKoopaLeftOrRightCollision },
            { (typeof(Koopa),  typeof(Koopa), Direction.top),  EnemyVSKoopaTopCollision },
            { (typeof(Koopa),  typeof(Koopa), Direction.bottom),  KoopaVSKoopaBottomCollision },

        };
        private static void KoopaVSKoopaBottomCollision(IEnemy koopa1, IEnemy koopa2, Direction direction)
        {
            EnemyVSKoopaTopCollision(koopa2, koopa1, ReverseDirection(direction));
        }

        private static void EnemyVSKoopaTopCollision(IEnemy enemy, IEnemy koopa, Direction direction)
        {
            if (koopa.HealthState is KoopaNormalState)
            {
                koopa.Stomped(1);
                Bump(enemy);
            }
            else if (!((Koopa)koopa).DealDemage)
            {
                if (koopa.MovementState is KoopaIdleState)
                {
                    if (enemy.HitBox().Center.X <= koopa.HitBox().Center.X)
                    {
                        koopa.MoveRight();
                        ((Koopa)koopa).DealDemage = true;
                    }
                    else
                    {
                        koopa.MoveLeft();
                        ((Koopa)koopa).DealDemage = true;
                    }
                }
                else
                {
                    koopa.Flipped(1);
                    koopa.ObjState = ObjectState.NonCollidable;
                }
            }
            ResolveOverlap(enemy, koopa, direction);
        }
        private static void EnemyKoopaLeftOrRightCollision(IEnemy goomba, IEnemy enemy, Direction direction)
        {
            Koopa koopa = (Koopa)enemy;
            if (koopa.HealthState is KoopaNormalState)
            {
                koopa.ChangeDirection();
                goomba.ChangeDirection();
            }
            else if (koopa.HealthState is KoopaShelledState)
            {
                if (koopa.MovementState is KoopaIdleState)
                    goomba.ChangeDirection();
                else
                {
                    goomba.Flipped(1);
                    goomba.ObjState = ObjectState.NonCollidable;
                }
            }
        }
        private static void GeneralEnemyTopCollision(IEnemy enemy1, IEnemy enemy2, Direction direction)
        {
            enemy2.Stomped(1);
            Bump(enemy1);
        }
        private static void GeneralEnemyLeftOrRightCollision(IEnemy enemy1, IEnemy enemy2, Direction direction)
        {
            enemy1.ChangeDirection();
            enemy2.ChangeDirection();
        }
    }
}
