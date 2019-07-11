using SuperMarioBros.Marios;
using SuperMarioBros.Objects.Enemy;
using System;
using System.Collections.Generic;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Mario.MarioTransitionState;

namespace SuperMarioBros.Collisions
{
    public class MarioEnemyResponder : MarioEnemyCollisionHandler, ICollisionResponder
    {
        private delegate void MarioEnemyHandler(IMario mario, IEnemy enemy);

        public void HandleCollision(IObject mover, IObject target, Direction direction)
        {
            IMario mario = (IMario)mover;
            if (target is Goomba goomba)
            {
                var key = (mario.TransitionState.GetType(), direction);
                if (GoombahandlerDictionary.ContainsKey(key))
                    GoombahandlerDictionary[key](mario, goomba);
            }
            else if (target is Koopa koopa)
            {
                var key = (mario.TransitionState.GetType(), koopa.HealthState.GetType(), koopa.MovementState.GetType(), direction);
                if (koopaHandlerDictionary.ContainsKey(key))
                    koopaHandlerDictionary[key](mario, koopa);
            }
        }

        private readonly Dictionary<(Type, Direction), MarioEnemyHandler> GoombahandlerDictionary = new Dictionary<(Type, Direction), MarioEnemyHandler>
        {
            { (typeof(NormalState), Direction.top), NormalMarioVsEnemyTopSideCollision},
            { (typeof(StarState), Direction.top), StarMarioVsEnemy},

            { (typeof(NormalState), Direction.left), NormalMarioTakeDamage},
            { (typeof(StarState), Direction.left), StarMarioVsEnemy},

            { (typeof(NormalState), Direction.right), NormalMarioTakeDamage},
            { (typeof(StarState), Direction.right), StarMarioVsEnemy},

            { (typeof(NormalState), Direction.bottom), NormalMarioTakeDamage},
            { (typeof(StarState), Direction.bottom), StarMarioVsEnemy},
        };

        private readonly Dictionary<(Type, Type, Type, Direction), MarioEnemyHandler> koopaHandlerDictionary = new Dictionary<(Type, Type, Type, Direction), MarioEnemyHandler>
        {
            { (typeof(NormalState), typeof(KoopaNormalState), typeof(KoopaIdleState) , Direction.top), NormalMarioVsEnemyTopSideCollision},
            { (typeof(NormalState), typeof(KoopaNormalState), typeof(KoopaLeftMovingState) , Direction.top), NormalMarioVsEnemyTopSideCollision},
            { (typeof(NormalState), typeof(KoopaNormalState), typeof(KoopaRightMovingState) , Direction.top), NormalMarioVsEnemyTopSideCollision},

            { (typeof(NormalState), typeof(KoopaShelledState), typeof(KoopaIdleState) , Direction.top), NormalMarioVsShelledIdleKoopaTopSideCollision},
            { (typeof(NormalState), typeof(KoopaShelledState), typeof(KoopaLeftMovingState) , Direction.top), NormalMarioVsShelledMovingKoopaTopSideCollision},
            { (typeof(NormalState), typeof(KoopaShelledState), typeof(KoopaRightMovingState) , Direction.top), NormalMarioVsShelledMovingKoopaTopSideCollision},

            { (typeof(StarState), typeof(KoopaNormalState), typeof(KoopaIdleState) , Direction.top), StarMarioVsEnemy},
            { (typeof(StarState), typeof(KoopaNormalState), typeof(KoopaLeftMovingState) , Direction.top), StarMarioVsEnemy},
            { (typeof(StarState), typeof(KoopaNormalState), typeof(KoopaRightMovingState) , Direction.top),StarMarioVsEnemy},

            { (typeof(StarState), typeof(KoopaShelledState), typeof(KoopaIdleState) , Direction.top), StarMarioVsEnemy},
            { (typeof(StarState), typeof(KoopaShelledState), typeof(KoopaLeftMovingState) , Direction.top), StarMarioVsEnemy},
            { (typeof(StarState), typeof(KoopaShelledState), typeof(KoopaRightMovingState) , Direction.top), StarMarioVsEnemy},

            { (typeof(NormalState), typeof(KoopaNormalState), typeof(KoopaIdleState) , Direction.left), NormalMarioTakeDamage},
            { (typeof(NormalState), typeof(KoopaNormalState), typeof(KoopaLeftMovingState) , Direction.left), NormalMarioTakeDamage},
            { (typeof(NormalState), typeof(KoopaNormalState), typeof(KoopaRightMovingState) , Direction.left), NormalMarioTakeDamage},

            { (typeof(NormalState), typeof(KoopaShelledState), typeof(KoopaIdleState) , Direction.left), MoveShelledIdleKoopa},
            { (typeof(NormalState), typeof(KoopaShelledState), typeof(KoopaLeftMovingState) , Direction.left), NormalMarioVsShelledMovingKoopaLeftOrRightCollision},
            { (typeof(NormalState), typeof(KoopaShelledState), typeof(KoopaRightMovingState) , Direction.left), NormalMarioVsShelledMovingKoopaLeftOrRightCollision},

            { (typeof(StarState), typeof(KoopaNormalState), typeof(KoopaIdleState) , Direction.left), StarMarioVsEnemy},
            { (typeof(StarState), typeof(KoopaNormalState), typeof(KoopaLeftMovingState) , Direction.left), StarMarioVsEnemy},
            { (typeof(StarState), typeof(KoopaNormalState), typeof(KoopaRightMovingState) , Direction.left),StarMarioVsEnemy},

            { (typeof(StarState), typeof(KoopaShelledState), typeof(KoopaIdleState) , Direction.left), StarMarioVsEnemy},
            { (typeof(StarState), typeof(KoopaShelledState), typeof(KoopaLeftMovingState) , Direction.left), StarMarioVsEnemy},
            { (typeof(StarState), typeof(KoopaShelledState), typeof(KoopaRightMovingState) , Direction.left), StarMarioVsEnemy},

            { (typeof(NormalState), typeof(KoopaNormalState), typeof(KoopaIdleState) , Direction.right), NormalMarioTakeDamage},
            { (typeof(NormalState), typeof(KoopaNormalState), typeof(KoopaLeftMovingState) , Direction.right), NormalMarioTakeDamage},
            { (typeof(NormalState), typeof(KoopaNormalState), typeof(KoopaRightMovingState) , Direction.right), NormalMarioTakeDamage},

            { (typeof(NormalState), typeof(KoopaShelledState), typeof(KoopaIdleState) , Direction.right), MoveShelledIdleKoopa},
            { (typeof(NormalState), typeof(KoopaShelledState), typeof(KoopaLeftMovingState) , Direction.right), NormalMarioVsShelledMovingKoopaLeftOrRightCollision},
            { (typeof(NormalState), typeof(KoopaShelledState), typeof(KoopaRightMovingState) , Direction.right), NormalMarioVsShelledMovingKoopaLeftOrRightCollision},

            { (typeof(StarState), typeof(KoopaNormalState), typeof(KoopaIdleState) , Direction.right), StarMarioVsEnemy},
            { (typeof(StarState), typeof(KoopaNormalState), typeof(KoopaLeftMovingState) , Direction.right), StarMarioVsEnemy},
            { (typeof(StarState), typeof(KoopaNormalState), typeof(KoopaRightMovingState) , Direction.right),StarMarioVsEnemy},

            { (typeof(StarState), typeof(KoopaShelledState), typeof(KoopaIdleState) , Direction.right), StarMarioVsEnemy},
            { (typeof(StarState), typeof(KoopaShelledState), typeof(KoopaLeftMovingState) , Direction.right), StarMarioVsEnemy},
            { (typeof(StarState), typeof(KoopaShelledState), typeof(KoopaRightMovingState) , Direction.right), StarMarioVsEnemy},

            { (typeof(NormalState), typeof(KoopaNormalState), typeof(KoopaIdleState) , Direction.bottom), NormalMarioTakeDamage},
            { (typeof(NormalState), typeof(KoopaNormalState), typeof(KoopaLeftMovingState) , Direction.bottom), NormalMarioTakeDamage},
            { (typeof(NormalState), typeof(KoopaNormalState), typeof(KoopaRightMovingState) , Direction.bottom), NormalMarioTakeDamage},

            { (typeof(NormalState), typeof(KoopaShelledState), typeof(KoopaIdleState) , Direction.bottom), NormalMarioTakeDamage},
            { (typeof(NormalState), typeof(KoopaShelledState), typeof(KoopaLeftMovingState) , Direction.bottom), NormalMarioTakeDamage},
            { (typeof(NormalState), typeof(KoopaShelledState), typeof(KoopaRightMovingState) , Direction.bottom), NormalMarioTakeDamage},

            { (typeof(StarState), typeof(KoopaNormalState), typeof(KoopaIdleState) , Direction.bottom), StarMarioVsEnemy},
            { (typeof(StarState), typeof(KoopaNormalState), typeof(KoopaLeftMovingState) , Direction.bottom), StarMarioVsEnemy},
            { (typeof(StarState), typeof(KoopaNormalState), typeof(KoopaRightMovingState) , Direction.bottom),StarMarioVsEnemy},

            { (typeof(StarState), typeof(KoopaShelledState), typeof(KoopaIdleState) , Direction.bottom), StarMarioVsEnemy},
            { (typeof(StarState), typeof(KoopaShelledState), typeof(KoopaLeftMovingState) , Direction.bottom), StarMarioVsEnemy},
            { (typeof(StarState), typeof(KoopaShelledState), typeof(KoopaRightMovingState) , Direction.bottom), StarMarioVsEnemy},
        };
    }
}
