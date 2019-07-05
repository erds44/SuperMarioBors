using SuperMarioBros.Blocks;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Object.Pipes;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class DynamicAndStaticObjectsHandler : IHandler
    {
        private static Dictionary<(Type, Type), Type> collisionDictionary;
        public DynamicAndStaticObjectsHandler()
        {
            collisionDictionary = new Dictionary<(Type, Type), Type>
            {
                { (typeof(IMario), typeof(IBlock)), typeof(MarioBlockResponse)},
                { (typeof(IMario), typeof(IPipe)), typeof(MarioPipeResponse)},
                { (typeof(IItem), typeof(IBlock)), typeof(ItemBlockResponse)},
                { (typeof(IItem), typeof(IPipe)), typeof(ItemPipeResponse)},
                { (typeof(IEnemy), typeof(IBlock)), typeof(EnemyBlockResponse)},
                { (typeof(IEnemy), typeof(IPipe)), typeof(EnemyPipeResponse)},
            };
        }
        public void HandleCollision(IObject obj1, IObject obj2, Direction direction)
        {
            if (collisionDictionary.TryGetValue((((IDynamic)obj1).GetType().GetInterfaces()[0],((IStatic)obj2).GetType().GetInterfaces()[0]), out Type type))
                ((ICollisionResponsible)Activator.CreateInstance(type, obj1, obj2, direction)).HandleCollision();
        }

    }
}