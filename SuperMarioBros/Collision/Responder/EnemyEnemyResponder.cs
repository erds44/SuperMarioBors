using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class EnemyEnemyResponder : EnemyEnemyCollisionHandler, ICollisionResponder
    {
        private delegate void EnemyEnemyHandler(IEnemy enemy1, IEnemy enemy2, Direction direction);

        public void HandleCollision(IObject mover, IObject target, Direction direction)
        {
            IEnemy moverEnemy = (IEnemy)mover;
            IEnemy targetEnemy = (IEnemy)target;

            var key1 = (moverEnemy.GetType(), targetEnemy.GetType(), direction);
            var key2 = (moverEnemy.GetType(), targetEnemy.HealthState.GetType(), targetEnemy.MovementState.GetType(), direction);
            var key3 = (targetEnemy.GetType(), moverEnemy.HealthState.GetType(), moverEnemy.MovementState.GetType(), ReverseDirection(direction));
            if (goombaVsGoombaHandlerDictionary.ContainsKey(key1))
                goombaVsGoombaHandlerDictionary[key1](moverEnemy, targetEnemy, direction);
            else if (handlerDictionary.ContainsKey(key2))
                handlerDictionary[key2](moverEnemy, targetEnemy, direction);
            else if(handlerDictionary.ContainsKey(key3))
                handlerDictionary[key3](targetEnemy, moverEnemy, ReverseDirection(direction));

        }
        private readonly Dictionary<(Type, Type, Type, Direction), EnemyEnemyHandler> handlerDictionary = new Dictionary<(Type, Type, Type, Direction), EnemyEnemyHandler>
        {
            { (typeof(Goomba), typeof(KoopaNormalState), typeof(KoopaIdleState), Direction.top), MoverStompsTarget},
            { (typeof(Goomba), typeof(KoopaNormalState), typeof(KoopaLeftMovingState), Direction.top), MoverStompsTarget},
            { (typeof(Goomba), typeof(KoopaNormalState), typeof(KoopaRightMovingState), Direction.top), MoverStompsTarget},

            { (typeof(Goomba), typeof(KoopaShelledState), typeof(KoopaIdleState), Direction.top), EnemyVsShelledIdleKoopaTopCollision},
            { (typeof(Goomba), typeof(KoopaShelledState), typeof(KoopaLeftMovingState), Direction.top), EnemyVsShelledMovingKoopaTopCollision},
            { (typeof(Goomba), typeof(KoopaShelledState), typeof(KoopaRightMovingState), Direction.top), EnemyVsShelledMovingKoopaTopCollision},

            { (typeof(Goomba), typeof(KoopaNormalState), typeof(KoopaIdleState), Direction.left), EnemyChangeDirection},
            { (typeof(Goomba), typeof(KoopaNormalState), typeof(KoopaLeftMovingState), Direction.left), EnemyChangeDirection},
            { (typeof(Goomba), typeof(KoopaNormalState), typeof(KoopaRightMovingState), Direction.left), EnemyChangeDirection},

            { (typeof(Goomba), typeof(KoopaShelledState), typeof(KoopaIdleState), Direction.left), MoverChangeDirection},
            { (typeof(Goomba), typeof(KoopaShelledState), typeof(KoopaLeftMovingState), Direction.left), MoverFlipped},
            { (typeof(Goomba), typeof(KoopaShelledState), typeof(KoopaRightMovingState), Direction.left), MoverFlipped},

            { (typeof(Goomba), typeof(KoopaNormalState), typeof(KoopaIdleState), Direction.right), EnemyChangeDirection},
            { (typeof(Goomba), typeof(KoopaNormalState), typeof(KoopaLeftMovingState), Direction.right), EnemyChangeDirection},
            { (typeof(Goomba), typeof(KoopaNormalState), typeof(KoopaRightMovingState), Direction.right), EnemyChangeDirection},

            { (typeof(Goomba), typeof(KoopaShelledState), typeof(KoopaIdleState), Direction.right), MoverChangeDirection},
            { (typeof(Goomba), typeof(KoopaShelledState), typeof(KoopaLeftMovingState), Direction.right), MoverFlipped},
            { (typeof(Goomba), typeof(KoopaShelledState), typeof(KoopaRightMovingState), Direction.right), MoverFlipped},

            { (typeof(Goomba), typeof(KoopaNormalState), typeof(KoopaIdleState), Direction.bottom), TargetStompsMover},
            { (typeof(Goomba), typeof(KoopaNormalState), typeof(KoopaLeftMovingState), Direction.bottom), TargetStompsMover},
            { (typeof(Goomba), typeof(KoopaNormalState), typeof(KoopaRightMovingState), Direction.bottom), TargetStompsMover},

            { (typeof(Goomba), typeof(KoopaShelledState), typeof(KoopaIdleState), Direction.bottom), TargetStompsMover},
            { (typeof(Goomba), typeof(KoopaShelledState), typeof(KoopaLeftMovingState), Direction.bottom), TargetStompsMover},
            { (typeof(Goomba), typeof(KoopaShelledState), typeof(KoopaRightMovingState), Direction.bottom), TargetStompsMover},

            { (typeof(Koopa), typeof(KoopaNormalState), typeof(KoopaIdleState), Direction.top), MoverStompsTarget},
            { (typeof(Koopa), typeof(KoopaNormalState), typeof(KoopaLeftMovingState), Direction.top), MoverStompsTarget},
            { (typeof(Koopa), typeof(KoopaNormalState), typeof(KoopaRightMovingState), Direction.top), MoverStompsTarget},

            { (typeof(Koopa), typeof(KoopaShelledState), typeof(KoopaIdleState), Direction.top), EnemyVsShelledIdleKoopaTopCollision},
            { (typeof(Koopa), typeof(KoopaShelledState), typeof(KoopaLeftMovingState), Direction.top), EnemyVsShelledMovingKoopaTopCollision},
            { (typeof(Koopa), typeof(KoopaShelledState), typeof(KoopaRightMovingState), Direction.top), EnemyVsShelledMovingKoopaTopCollision},

            { (typeof(Koopa), typeof(KoopaNormalState), typeof(KoopaIdleState), Direction.left), EnemyChangeDirection},
            { (typeof(Koopa), typeof(KoopaNormalState), typeof(KoopaLeftMovingState), Direction.left), EnemyChangeDirection},
            { (typeof(Koopa), typeof(KoopaNormalState), typeof(KoopaRightMovingState), Direction.left), EnemyChangeDirection},

            { (typeof(Koopa), typeof(KoopaShelledState), typeof(KoopaIdleState), Direction.left), MoverChangeDirection},
            { (typeof(Koopa), typeof(KoopaShelledState), typeof(KoopaLeftMovingState), Direction.left), MoverFlipped},
            { (typeof(Koopa), typeof(KoopaShelledState), typeof(KoopaRightMovingState), Direction.left), MoverFlipped},

            { (typeof(Koopa), typeof(KoopaNormalState), typeof(KoopaIdleState), Direction.right), EnemyChangeDirection},
            { (typeof(Koopa), typeof(KoopaNormalState), typeof(KoopaLeftMovingState), Direction.right), EnemyChangeDirection},
            { (typeof(Koopa), typeof(KoopaNormalState), typeof(KoopaRightMovingState), Direction.right), EnemyChangeDirection},

            { (typeof(Koopa), typeof(KoopaShelledState), typeof(KoopaIdleState), Direction.right), MoverChangeDirection},
            { (typeof(Koopa), typeof(KoopaShelledState), typeof(KoopaLeftMovingState), Direction.right), MoverFlipped},
            { (typeof(Koopa), typeof(KoopaShelledState), typeof(KoopaRightMovingState), Direction.right), MoverFlipped},

            { (typeof(Koopa), typeof(KoopaNormalState), typeof(KoopaIdleState), Direction.bottom), TargetStompsMover},
            { (typeof(Koopa), typeof(KoopaNormalState), typeof(KoopaLeftMovingState), Direction.bottom), TargetStompsMover},
            { (typeof(Koopa), typeof(KoopaNormalState), typeof(KoopaRightMovingState), Direction.bottom), TargetStompsMover},

            { (typeof(Koopa), typeof(KoopaShelledState), typeof(KoopaIdleState), Direction.bottom), TargetStompsMover},
            { (typeof(Koopa), typeof(KoopaShelledState), typeof(KoopaLeftMovingState), Direction.bottom), TargetStompsMover},
            { (typeof(Koopa), typeof(KoopaShelledState), typeof(KoopaRightMovingState), Direction.bottom), TargetStompsMover},
        };

        private readonly Dictionary<(Type, Type, Direction), EnemyEnemyHandler> goombaVsGoombaHandlerDictionary = new Dictionary<(Type, Type, Direction), EnemyEnemyHandler>
        {
            { (typeof(Goomba),  typeof(Goomba), Direction.right), EnemyChangeDirection},
            { (typeof(Goomba),  typeof(Goomba), Direction.left), EnemyChangeDirection},
            { (typeof(Goomba),  typeof(Goomba), Direction.top), MoverStompsTarget},
            { (typeof(Goomba),  typeof(Goomba), Direction.bottom), TargetStompsMover},
        };
    }
}
