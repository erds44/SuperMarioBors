using Microsoft.Xna.Framework;
using SuperMarioBros.Items;
using SuperMarioBros.Managers;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Object
{
    public static class ObjectFactory
    {
        private static ObjectsManager objectsManager;
        private static Vector2 itemOffset = new Vector2(5, 0);  /* includes muhsrooms, star, flower */
        private static Vector2 coinOffset = new Vector2(15, -50);
        private static Vector2 leftTopDebrisOffset = new Vector2(0, -40);
        private static Vector2 rightTopDebrisOffset = new Vector2(20, -40);
        private static Vector2 rightBottomDebrisOffset = new Vector2(20, 0);

        public static void Initialize(MarioGame game)
        {
            objectsManager = game.ObjectsManager;
        }
        /* Mainly used for itemBlock creates items*/
        public static void CreateNonCollidableObject(Type type, Vector2 location)
        {
            Vector2 offSet = Vector2.Zero;
            if (dictionary.TryGetValue(type, out offSet))
                location += offSet;
            objectsManager.AddNonCollidableObject((IDynamic)Activator.CreateInstance(type, location));
        }

        public static void CreateCollidableObject(Type type, Vector2 location)
        {
            objectsManager.AddObject((IStatic)Activator.CreateInstance(type, location));
        }

        public static void CreateBlockDebris(Vector2 location)
        {
            objectsManager.AddNonCollidableObject(new BrickDerbis(location + leftTopDebrisOffset, BrickPosition.leftTop));
            objectsManager.AddNonCollidableObject(new BrickDerbis(location, BrickPosition.leftBottom));
            objectsManager.AddNonCollidableObject(new BrickDerbis(location + rightTopDebrisOffset, BrickPosition.rightTop));
            objectsManager.AddNonCollidableObject(new BrickDerbis(location + rightBottomDebrisOffset, BrickPosition.rightBottom));
        }
        
        public static void CreateFireBall(Vector2 location, fireBallDirection direction)
        {
            objectsManager.AddObject((IDynamic)Activator.CreateInstance(typeof(FireBall), location, direction));
        }

        /* Red/Green msuhrrom, star, debris, flower, coin*/
        private static Dictionary<Type, Vector2> dictionary = new Dictionary<Type, Vector2>
        {
            { typeof(RedMushroom), itemOffset},
            { typeof(GreenMushroom), itemOffset},
            { typeof(Flower), itemOffset},
            { typeof(Star), itemOffset},
            { typeof(Coin), coinOffset},
        };

    }

}
