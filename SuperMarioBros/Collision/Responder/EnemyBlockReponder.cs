using SuperMarioBros.Blocks;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class EnemyBlockResponder : EnemyBlockCollisionHandler, ICollisionResponder
    {
        private delegate void EnemyBlockHandler (IEnemy enemy, IBlock block, Direction direction);

        public void HandleCollision(IObject mover, IObject target, Direction direction)
        {
            IEnemy enemy = (IEnemy)mover;
            IBlock block = (IBlock)target;
            var key = (enemy.GetType(), block.State.GetType(), direction);
            if (!(block is HiddenBlock) && handlerDictionary.ContainsKey(key))
                handlerDictionary[key](enemy, block, direction);
        }

        private readonly Dictionary<(Type,Type,Direction), EnemyBlockHandler> handlerDictionary = new Dictionary<(Type, Type, Direction), EnemyBlockHandler>
        {

            { (typeof(Goomba), typeof(BumpedState), Direction.top), GoombaBumped},
            { (typeof(Goomba), typeof(NormalState), Direction.top), MoverOnGround},

            { (typeof(Goomba), typeof(BumpedState), Direction.left), EnemyHorizontallyBounce},
            { (typeof(Goomba), typeof(NormalState), Direction.left), EnemyHorizontallyBounce},

            { (typeof(Goomba), typeof(BumpedState), Direction.right), EnemyHorizontallyBounce},
            { (typeof(Goomba), typeof(NormalState), Direction.right), EnemyHorizontallyBounce},

            { (typeof(Goomba), typeof(BumpedState), Direction.bottom), MoverVerticallyBounce},
            { (typeof(Goomba), typeof(NormalState), Direction.bottom), MoverVerticallyBounce },

            { (typeof(Koopa), typeof(BumpedState), Direction.top), KoopaBumped},
            { (typeof(Koopa), typeof(NormalState), Direction.top), MoverOnGround},

            { (typeof(Koopa), typeof(BumpedState), Direction.left), EnemyHorizontallyBounce},
            { (typeof(Koopa), typeof(NormalState), Direction.left), EnemyHorizontallyBounce},

            { (typeof(Koopa), typeof(BumpedState), Direction.right), EnemyHorizontallyBounce},
            { (typeof(Koopa), typeof(NormalState), Direction.right), EnemyHorizontallyBounce},

            { (typeof(Koopa), typeof(BumpedState), Direction.bottom), MoverVerticallyBounce},
            { (typeof(Koopa), typeof(NormalState), Direction.bottom), MoverVerticallyBounce },
        };




    }
}
