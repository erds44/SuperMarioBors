using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Items;
using SuperMarioBros.Managers;
using SuperMarioBros.Marios;
using SuperMarioBros.Stats;
using SuperMarioBros.Utility;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Objects
{
    public class ObjectFactory
    {
        public static ObjectFactory Instance { get; } = new ObjectFactory();
        private  ObjectsManager objectsManager;
        private static Vector2 itemOffset = Locations.ItemOffset;  /* includes muhsrooms, star, flower */
        private static Vector2 coinOffset = Locations.CoinOffset;
        private static Vector2 leftTopDebrisOffset = Locations.LeftTopDebrisOffset;
        private static Vector2 rightTopDebrisOffset = Locations.RightTopDebrisOffset;
        private static Vector2 rightBottomDebrisOffset = Locations.RightBottomDebrisOffset;
        private static Vector2 flagOffset = Locations.FlagOffset;
        public int Count { get; set; } = GeneralConstants.InitialCount;
        private  MarioGame game;
        private SpriteFont spriteFont;
        /* Red/Green msuhrrom, star, debris, flower, coin*/
        private readonly static Dictionary<Type, Vector2> dictionary = new Dictionary<Type, Vector2>
        {
            { typeof(RedMushroom), itemOffset},
            { typeof(GreenMushroom), itemOffset},
            { typeof(Flower), itemOffset},
            { typeof(Star), itemOffset},
            { typeof(Coin), coinOffset},
            { typeof(WinFlag), flagOffset}
        };

        public void Initialize(MarioGame marioGame)
        {
            this.game = marioGame;
            objectsManager = marioGame.ObjectsManager;
            spriteFont = marioGame.Content.Load<SpriteFont>(StringConsts.Font);
        }
        /* Mainly used for itemBlock creates items*/
        public void CreateNonCollidableObject(Type type, Vector2 location)
        {
            if (dictionary.TryGetValue(type, out Vector2 offSet))
                location += offSet;
            IDynamic obj = (IDynamic)Activator.CreateInstance(type, location);
            objectsManager.AddNonCollidableObject(obj);
            if (type == typeof(Coin))
            {
                StatsManager.Instance.CoinCollected(new Vector2(location.X, location.Y + Locations.ScoreOffset));
                AudioFactory.Instance.CreateSound(StringConsts.Coin).Play();
            }
            if (obj is WinFlag winFlag)
                winFlag.StartOverEvent += game.StartOver;        
        }

        public void CreateCollidableObject(Type type, Vector2 location)
        {
            objectsManager.AddObject((IStatic)Activator.CreateInstance(type, location));
        }

        public  void CreateBlockDebris(Vector2 location, Type type)
        {
            objectsManager.AddNonCollidableObject(new BrickDerbis(location + leftTopDebrisOffset, BrickPosition.leftTop, type));
            objectsManager.AddNonCollidableObject(new BrickDerbis(location, BrickPosition.leftBottom, type));
            objectsManager.AddNonCollidableObject(new BrickDerbis(location + rightTopDebrisOffset, BrickPosition.rightTop, type));
            objectsManager.AddNonCollidableObject(new BrickDerbis(location + rightBottomDebrisOffset, BrickPosition.rightBottom, type));
        }
        
        public void CreateFireBall(Vector2 location, FireBallDirection direction)
        {
            objectsManager.AddObject((IDynamic)Activator.CreateInstance(typeof(FireBall), location, direction));
        }

        public void CreateScoreText(Vector2 location, string str)
        {
            objectsManager.AddNonCollidableObject(new ScoreText(location, spriteFont, str));
        }

    }

}
