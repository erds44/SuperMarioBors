using SuperMarioBros.Blocks;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class ItemBlockResponder : ItemBlockCollisionHandler, ICollisionResponder
    {
        private delegate void ItemBlockHandler(IItem item, IBlock block, Direction direction);
        public void HandleCollision(IObject mover, IObject target, Direction direction)
        {
            IItem item = (IItem)mover;
            IBlock block = (IBlock)target;
            var key = (item.GetType(), block.State.GetType(), direction);
            if (handlerDictionary.ContainsKey(key))
                handlerDictionary[key](item, block, direction);
        }
        private readonly Dictionary<(Type, Type, Direction), ItemBlockHandler> handlerDictionary = new Dictionary<(Type, Type, Direction), ItemBlockHandler>
        {
            { (typeof(Castle), typeof(NormalState), Direction.top), MoverOnGround},

            { (typeof(Flag), typeof(NormalState), Direction.top), MoverOnGround},

            { (typeof(FlagPole), typeof(NormalState), Direction.top), MoverOnGround},

            { (typeof(Flower), typeof(NormalState), Direction.top), MoverOnGround},

            { (typeof(FireBall), typeof(NormalState), Direction.top), MoverVerticallyBounce},
            { (typeof(FireBall), typeof(BumpedState), Direction.top), MoverVerticallyBounce},

            { (typeof(FireBall), typeof(NormalState), Direction.bottom), MoverVerticallyBounce},
            { (typeof(FireBall), typeof(BumpedState), Direction.bottom), MoverVerticallyBounce},

            { (typeof(FireBall), typeof(NormalState), Direction.left), FireBallExplosion},
            { (typeof(FireBall), typeof(BumpedState), Direction.left), FireBallExplosion},

            { (typeof(FireBall), typeof(NormalState), Direction.right), FireBallExplosion},
            { (typeof(FireBall), typeof(BumpedState), Direction.right), FireBallExplosion},

            { (typeof(GreenMushroom), typeof(NormalState), Direction.top), MoverOnGround},
            { (typeof(GreenMushroom), typeof(BumpedState), Direction.top), ItemBumpedOrChangeDirection},

            { (typeof(GreenMushroom), typeof(NormalState), Direction.bottom), MoverVerticallyBounce},
            { (typeof(GreenMushroom), typeof(BumpedState), Direction.bottom), MoverVerticallyBounce},

            { (typeof(GreenMushroom), typeof(NormalState), Direction.left), MoverHorizontallyBounce},
            { (typeof(GreenMushroom), typeof(BumpedState), Direction.left), MoverHorizontallyBounce},

            { (typeof(GreenMushroom), typeof(NormalState), Direction.right), MoverHorizontallyBounce},
            { (typeof(GreenMushroom), typeof(BumpedState), Direction.right), MoverHorizontallyBounce},

            { (typeof(RedMushroom), typeof(NormalState), Direction.top), MoverOnGround},
            { (typeof(RedMushroom), typeof(BumpedState), Direction.top), ItemBumpedOrChangeDirection},

            { (typeof(RedMushroom), typeof(NormalState), Direction.bottom), MoverVerticallyBounce},
            { (typeof(RedMushroom), typeof(BumpedState), Direction.bottom), MoverVerticallyBounce},

            { (typeof(RedMushroom), typeof(NormalState), Direction.left), MoverHorizontallyBounce},
            { (typeof(RedMushroom), typeof(BumpedState), Direction.left), MoverHorizontallyBounce},

            { (typeof(RedMushroom), typeof(NormalState), Direction.right), MoverHorizontallyBounce},
            { (typeof(RedMushroom), typeof(BumpedState), Direction.right), MoverHorizontallyBounce},

            { (typeof(Star), typeof(NormalState), Direction.top), MoverVerticallyBounce},
            { (typeof(Star), typeof(BumpedState), Direction.top), ItemBumpedOrChangeDirection},

            { (typeof(Star), typeof(NormalState), Direction.bottom), MoverVerticallyBounce},
            { (typeof(Star), typeof(BumpedState), Direction.bottom), MoverVerticallyBounce},

            { (typeof(Star), typeof(NormalState), Direction.left), MoverHorizontallyBounce},
            { (typeof(Star), typeof(BumpedState), Direction.left), MoverHorizontallyBounce},

            { (typeof(Star), typeof(NormalState), Direction.right), MoverHorizontallyBounce},
            { (typeof(Star), typeof(BumpedState), Direction.right), MoverHorizontallyBounce},
        };
    }
}
