using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Items;
using SuperMarioBros.Managers;
using SuperMarioBros.Marios;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Objects
{
    public class ObjectFactory
    {
        public event Action<Vector2> ItemCollectedEvent;
        private static readonly ObjectFactory instance = new ObjectFactory();
        public  static ObjectFactory Instance { get { return instance; } }
        private  ObjectsManager objectsManager;
        private static Vector2 itemOffset = new Vector2(1, 0);  /* includes muhsrooms, star, flower */
        private static Vector2 coinOffset = new Vector2(12, -50);
        private  Vector2 leftTopDebrisOffset = new Vector2(0, -40);
        private  Vector2 rightTopDebrisOffset = new Vector2(20, -40);
        private  Vector2 rightBottomDebrisOffset = new Vector2(20, 0);
        public int count = 0;
        /* Red/Green msuhrrom, star, debris, flower, coin*/
        private readonly static Dictionary<Type, Vector2> dictionary = new Dictionary<Type, Vector2>
        {
            { typeof(RedMushroom), itemOffset},
            { typeof(GreenMushroom), itemOffset},
            { typeof(Flower), itemOffset},
            { typeof(Star), itemOffset},
            { typeof(Coin), coinOffset},
        };

        public void Initialize()
        {
            objectsManager = MarioGame.Instance.ObjectsManager;
        }
        /* Mainly used for itemBlock creates items*/
        public void CreateNonCollidableObject(Type type, Vector2 location)
        {
            if (dictionary.TryGetValue(type, out Vector2 offSet))
                location += offSet;
            objectsManager.AddNonCollidableObject((IDynamic)Activator.CreateInstance(type, location));
            if (type == typeof(Coin))
                ItemCollectedEvent?.Invoke(new Vector2(location.X, location.Y -60));
        }

        public void CreateCollidableObject(Type type, Vector2 location)
        {
            objectsManager.AddObject((IStatic)Activator.CreateInstance(type, location));
        }

        public  void CreateBlockDebris(Vector2 location)
        {
            objectsManager.AddNonCollidableObject(new BrickDerbis(location + leftTopDebrisOffset, BrickPosition.leftTop));
            objectsManager.AddNonCollidableObject(new BrickDerbis(location, BrickPosition.leftBottom));
            objectsManager.AddNonCollidableObject(new BrickDerbis(location + rightTopDebrisOffset, BrickPosition.rightTop));
            objectsManager.AddNonCollidableObject(new BrickDerbis(location + rightBottomDebrisOffset, BrickPosition.rightBottom));
        }
        
        public void CreateFireBall(Vector2 location, FireBallDirection direction)
        {
            objectsManager.AddObject((IDynamic)Activator.CreateInstance(typeof(FireBall), location, direction));
        }

        public void CreateScoreText(Vector2 location, SpriteFont inputSpriteFont, string str)
        {
            objectsManager.AddNonCollidableObject(new ScoreText(location, inputSpriteFont, str));
        }

    }

}
