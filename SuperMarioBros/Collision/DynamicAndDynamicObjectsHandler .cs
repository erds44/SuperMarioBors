using SuperMarioBros.Commands;
using SuperMarioBros.Goombas;
using SuperMarioBros.Items;
using SuperMarioBros.Koopas;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Enemy;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public static class DynamicAndDynamicObjectsHandler
    {
        private delegate void CollisionHandler(IDynamic obj1, IDynamic obj2, Direction direction);

        public static void HandleCollision(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            if (collisionDictionary.TryGetValue((obj1.GetType(), obj2.GetType()), out var handle))
                handle(obj1, obj2, direction);
        }
        private static readonly Dictionary<(Type, Type), CollisionHandler> collisionDictionary = new Dictionary<(Type, Type), CollisionHandler>
        {
             {(typeof(Mario), typeof(Star)), StarMario},
             {(typeof(Mario), typeof(RedMushroom)), RedMushroom},
             {(typeof(Mario), typeof(GreenMushroom)), GreenMushroom},
             {(typeof(Mario), typeof(Flower)), FireFlower},
             {(typeof(Mario), typeof(Coin)), Coin},

             {(typeof(StarMario), typeof(Star)), StarMario},
             {(typeof(StarMario), typeof(RedMushroom)), RedMushroom},
             {(typeof(StarMario), typeof(GreenMushroom)), GreenMushroom},
             {(typeof(StarMario), typeof(Flower)), FireFlower},
             {(typeof(StarMario), typeof(Coin)), Coin},

             {(typeof(FlashingMario), typeof(Star)), StarMario},
             {(typeof(FlashingMario), typeof(RedMushroom)), RedMushroom},
             {(typeof(FlashingMario), typeof(GreenMushroom)), GreenMushroom},
             {(typeof(FlashingMario), typeof(Flower)), FireFlower},
             {(typeof(FlashingMario), typeof(Coin)), Coin},

            // {(typeof(Mario), typeof(Goomba)), MarioGoomba},
             //{(typeof(Mario), typeof(Koopa)), MarioKoopa},
             

             {(typeof(StarMario), typeof(Goomba)), StarMarioEnemy},
             {(typeof(StarMario), typeof(Koopa)), StarMarioEnemy},
             

             {(typeof(FlashingMario), typeof(Goomba)), StarMario},
             {(typeof(FlashingMario), typeof(Koopa)), RedMushroom},
            

             {(typeof(Goomba), typeof(Goomba)), MoveEnemy},
             {(typeof(Goomba), typeof(Koopa)), MoveEnemy},


        };
        private static void StarMario(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            ObjectsManager.Instance.StarMario((IMario)obj1);
            ObjectsManager.Instance.Remove(obj2);
        }

        private static void RedMushroom(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            IMario mario = (IMario)obj1;
            mario.RedMushroom();        
            ObjectsManager.Instance.Remove(obj2);
        }
        private static void GreenMushroom(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            IMario mario = (IMario)obj1;
            mario.GreenMushroom();
            ObjectsManager.Instance.Remove(obj2);
        }
        private static void FireFlower(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            IMario mario = (IMario)obj1;
            mario.OnFireFlower();
            ObjectsManager.Instance.Remove(obj2);
        }
        private static void Coin(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            IMario mario = (IMario)obj1;
            mario.Coin();
            ObjectsManager.Instance.Remove(obj2);
        }

        private static void StarMarioEnemy(IDynamic ob1, IDynamic obj2, Direction direction)
        {
            ObjectsManager.Instance.Remove(obj2);
        }
        private static void MoveEnemy(IDynamic obj1, IDynamic obj2, Direction direction)
        {
          
            switch (direction)
            {
                case Direction.left: obj1.MoveRight(); obj2.MoveLeft(); break;
                case Direction.right: obj1.MoveLeft(); obj2.MoveRight(); break;
            }
        }
        
        private static void MarioGoomba(IDynamic obj1, IDynamic obj2,Direction direction)
        {
            
        }
    }
}
