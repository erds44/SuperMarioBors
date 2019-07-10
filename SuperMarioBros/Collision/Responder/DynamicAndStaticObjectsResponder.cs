using SuperMarioBros.Blocks;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Pipes;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class DynamicAndStaticObjectsHandler : ICollisionResponder
    {
        private readonly MarioGame game;
        public DynamicAndStaticObjectsHandler(MarioGame game)
        {
            this.game = game;
        }
        public void HandleCollision(IObject mover, IObject target, Direction direction)
        {
            if (collisionDictionary.TryGetValue((((IDynamic)mover).GetType().GetInterfaces()[0], ((IStatic)target).GetType().GetInterfaces()[0]), out var responder))
                responder.HandleCollision(mover, target, direction);
        }
        private static Dictionary<(Type, Type), ICollisionResponder> collisionDictionary = new Dictionary<(Type, Type), ICollisionResponder>
            {
                { (typeof(IMario), typeof(IBlock)), new MarioBlockResponder()},
                { (typeof(IMario), typeof(IPipe)), new MarioPipeResponder()},
                { (typeof(IItem), typeof(IBlock)), new ItemBlockResponder()},
                { (typeof(IItem), typeof(IPipe)), new ItemPipeResponder()},
                { (typeof(IEnemy), typeof(IBlock)), new EnemyBlockResponder()},
                { (typeof(IEnemy), typeof(IPipe)), new EnemyPipeResponder()},
            };

    }
}