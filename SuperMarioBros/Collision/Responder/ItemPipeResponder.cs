using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Object.Pipes;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class ItemPipeResponder : ItemPipeCollisionHandler, ICollisionResponder
    {
        private delegate void ItemPipeHandler(IItem item, IPipe pipe, Direction direction);

        public void HandleCollision(IObject mover, IObject target, Direction direction)
        {
            IItem item = (IItem)mover;
            IPipe pipe = (IPipe)target;
            var key = (item.GetType(), direction);
            if (handlerDictionary.ContainsKey(key))
                handlerDictionary[key](item, pipe, direction);
        }

        private readonly Dictionary<(Type, Direction), ItemPipeHandler> handlerDictionary = new Dictionary<(Type, Direction), ItemPipeHandler>
        {
            { (typeof(FireBall), Direction.top) , MoverVerticallyBounce},
            { (typeof(FireBall), Direction.left) , FireExplosion},
            { (typeof(FireBall), Direction.right) , FireExplosion},
            { (typeof(FireBall), Direction.bottom) , MoverVerticallyBounce},

            { (typeof(Star), Direction.top) , MoverVerticallyBounce},
            { (typeof(Star), Direction.left) , MoverHorizontallyBounce},
            { (typeof(Star), Direction.right) ,MoverHorizontallyBounce},
            { (typeof(Star), Direction.bottom) , MoverVerticallyBounce},

            { (typeof(RedMushroom), Direction.top) , MoverOnGround},
            { (typeof(RedMushroom), Direction.left) , MoverHorizontallyBounce},
            { (typeof(RedMushroom), Direction.right) ,MoverHorizontallyBounce},
            { (typeof(RedMushroom), Direction.bottom) , MoverVerticallyBounce},

            { (typeof(GreenMushroom), Direction.top) , MoverOnGround},
            { (typeof(GreenMushroom), Direction.left) , MoverHorizontallyBounce},
            { (typeof(GreenMushroom), Direction.right) ,MoverHorizontallyBounce},
            { (typeof(GreenMushroom), Direction.bottom) , MoverVerticallyBounce},
        };
    }
}
