using SuperMarioBros.Marios;
using SuperMarioBros.Objects.Enemy;
using System;
using System.Collections.Generic;
using SuperMarioBros.Object.Mario.MarioTransitionState;
using SuperMarioBros.Managers;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Collisions
{
    public class MarioEnemyResponse : GeneralResponse
    {
        private readonly IMario mario;
        private readonly IEnemy enemy;
        private readonly Direction direction;
        private delegate void MarioEnemyHandler(IMario mario, IEnemy enemy, Direction direction);

        public MarioEnemyResponse(IObject mario, IObject enemy, Direction direction)
        {
            this.mario = (IMario)mario;
            this.enemy = (IEnemy)enemy;
            this.direction = direction;
        }
        public override void HandleCollision()
        {
            if(!(mario.TransitionState is DamageState))
            {
                if (handlerDictionary.TryGetValue((enemy.GetType(), direction), out var handle))
                    handle(mario, enemy, direction);
            }
        }
        private readonly Dictionary<(Type,Direction), MarioEnemyHandler> handlerDictionary = new Dictionary<(Type,Direction), MarioEnemyHandler>
        {
            { (typeof(Koopa), Direction.top), KoopaTopCollision },
            { (typeof(Koopa), Direction.left), KoopaLeftOrRightCollision },
            { (typeof(Koopa), Direction.right), KoopaLeftOrRightCollision },
            { (typeof(Koopa), Direction.bottom), EnemyBottomCollision },
            { (typeof(Goomba), Direction.top),  GoombaTopCollision},
            { (typeof(Goomba), Direction.left),  GoombaLeftOrRightCollision},
            { (typeof(Goomba), Direction.right),  GoombaLeftOrRightCollision},
            { (typeof(Goomba), Direction.bottom), EnemyBottomCollision },

        };
        private static void GoombaLeftOrRightCollision(IMario mario, IEnemy enemy, Direction direction)
        {
            if (mario.TransitionState is StarState)
            {
                enemy.Flipped();
                enemy.ObjState = ObjectState.NonCollidable;
            }
            if(mario.TransitionState is NormalState)
                mario.TakeDamage();
        }
        private static void GoombaTopCollision(IMario mario, IEnemy enemy, Direction direction)
        {
            if (mario.TransitionState is NormalState)
            {
                Bump(mario);
                enemy.Stomped();
            }
            else if (mario.TransitionState is StarState)
            {
                enemy.Flipped();
                enemy.ObjState = ObjectState.NonCollidable;
            }
        }
        private static void EnemyBottomCollision(IMario mario, IEnemy enemy, Direction direction)
        {
            if (mario.TransitionState is StarState)
            {
                enemy.Flipped();
                enemy.ObjState = ObjectState.NonCollidable;
            }
            mario.TakeDamage();
        }
        private static void KoopaTopCollision(IMario mario, IEnemy enemy, Direction direction)
        {
            Koopa koopa = (Koopa)enemy;
            if (koopa.HealthState is KoopaNormalState)
            {
                koopa.Stomped();
                Bump(mario);
            }
            else if(!koopa.DealDemage)
            {
                if (koopa.MovementState is KoopaIdleState)
                {
                    if (mario.HitBox().Center.X <= koopa.HitBox().Center.X)
                    {
                        koopa.MovementState = new KoopaRightMovingState(koopa);
                        koopa.DealDemage = true;
                    }
                    else
                    {
                        koopa.MovementState = new KoopaLeftMovingState(koopa);
                        koopa.DealDemage = true;
                    }
                }
                else
                {
                    koopa.Flipped();
                    koopa.ObjState = ObjectState.NonCollidable;
                }
            }
            ResolveOverlap(mario, koopa, direction);
        }
        private static void KoopaLeftOrRightCollision(IMario mario, IEnemy enemy, Direction direction)
        {
            Koopa koopa = (Koopa)enemy;
            if (mario.TransitionState is StarState)
            {
                koopa.Flipped();
                koopa.ObjState = ObjectState.NonCollidable;
            }
            if (mario.TransitionState is NormalState)
            {
                if (koopa.HealthState is KoopaNormalState)
                {
                    mario.TakeDamage();
                }
                else if (koopa.HealthState is KoopaShelledState)
                {
                    if (koopa.MovementState is KoopaIdleState)
                    {
                        if (direction == Direction.left)
                            koopa.MoveRight();
                        else
                            koopa.MoveLeft();
                    }
                    else if (!koopa.DealDemage)
                    {
                        mario.TakeDamage();
                    }
                }
            }
        }


    }
}
