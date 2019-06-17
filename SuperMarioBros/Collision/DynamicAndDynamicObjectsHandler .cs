using SuperMarioBros.Blocks;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Commands;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public static class DynamicAndDynamicObjectsHandler
    {
        /* All CollisionHandler class will be refactored using delegate */
        private static readonly Dictionary<(Type, Type, Direction), (Type, Type)> collisionDictionary = new Dictionary<(Type, Type, Direction), (Type, Type)>
        {


        };

        public static void HandleCollision(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            if (collisionDictionary.TryGetValue((obj1.GetType(),obj2.GetType(), direction), out var types))
            {
                Type typ1 = types.Item1;
                Type typ2 = types.Item2;
                if (typ1 != typeof(Nullable))
                {
                    ((ICommand)Activator.CreateInstance(typ1, obj1)).Execute();
                }
                if (typ2 != typeof(Nullable))
                {
                    ((ICommand)Activator.CreateInstance(typ2, obj2)).Execute();
                }
            }
        }
    }
}
