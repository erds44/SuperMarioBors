using SuperMarioBros.Managers;
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

        };
        private Direction ReverseDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.bottom: return Direction.top;
                case Direction.top: return Direction.bottom;
                case Direction.left: return Direction.right;
            }
            return Direction.left;
        }
        private static void EnemyVSKoopaTopCollision(IEnemy goomba, IEnemy koopa, Direction direction)
        {
            if (koopa.HealthState is KoopaNormalState)
            {
                koopa.Stomped();
                Bump(goomba);
            }
            else if (!((Koopa)koopa).DealDemage)
            {
                if (koopa.MovementState is KoopaIdleState)
                {
                    if (goomba.HitBox().Center.X <= koopa.HitBox().Center.X)
                    {
                        koopa.MovementState = new KoopaRightMovingState((Koopa)koopa);
                        ((Koopa)koopa).DealDemage = true;
                    }
                    else
                    {
                        koopa.MovementState = new KoopaLeftMovingState((Koopa)koopa);
                        ((Koopa)koopa).DealDemage = true;
                    }
                }
                else
                {
                    koopa.Flipped();
                    koopa.ObjState = ObjectState.NonCollidable;
                }
            }
            ResolveOverlap(goomba, koopa, direction);
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
                    goomba.Flipped();
                    goomba.ObjState = ObjectState.NonCollidable;
                }
            }
        }
        private static void GeneralEnemyTopCollision(IEnemy enemy1, IEnemy enemy2, Direction direction)
        {
            enemy2.Stomped();
            Bump(enemy1);
        }
        private static void GeneralEnemyLeftOrRightCollision(IEnemy enemy1, IEnemy enemy2, Direction direction)
        {
            enemy1.ChangeDirection();
            enemy2.ChangeDirection();
        }
    }
}
