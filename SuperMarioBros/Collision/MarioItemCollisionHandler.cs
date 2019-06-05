using SuperMarioBros.Commands;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public static class MarioItemCollisionHandler
    {
        //private static Dictionary<Type, ICommand> collisionDictionary;
        public static bool HandleCollision(IMario mario, IItem item, Direction direction)
        {
            if (direction != Direction.none)
            {
                item.Collide(mario);
                if(item is Pipe)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        //private static void Initialize()
        //{
        //    collisionDictionary = new Dictionary<Type, ICommand>();
            
        //}
    }
}
