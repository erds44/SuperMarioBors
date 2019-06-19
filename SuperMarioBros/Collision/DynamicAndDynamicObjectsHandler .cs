using Microsoft.Xna.Framework;
using SuperMarioBros.Commands;
using SuperMarioBros.Goombas;
using SuperMarioBros.Items;
using SuperMarioBros.Koopas;
using SuperMarioBros.Marios;
using SuperMarioBros.Marios.MarioTypeStates;
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
                if(!(obj1.GetType() == typeof(Mario)&&((IMario)obj1).HealthState.GetType() == typeof(DeadMario)))
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

            {(typeof(Mario), typeof(Goomba)), MarioEnemy},
            {(typeof(Mario), typeof(Koopa)), MarioEnemy},
            {(typeof(Mario), typeof(StompedKoopa)), MarioStompedKoopa},

             {(typeof(StarMario), typeof(Goomba)), StarMarioEnemy},
             {(typeof(StarMario), typeof(Koopa)), StarMarioEnemy},
             {(typeof(StarMario), typeof(StompedKoopa)), StarMarioEnemy},
             

             //{(typeof(FlashingMario), typeof(Goomba)),MarioEnemy },
             //{(typeof(FlashingMario), typeof(Koopa)), MarioEnemy},
             //{(typeof(FlashingMario), typeof(StompedKoopa)), MarioStompedKoopa},


             {(typeof(Goomba), typeof(Goomba)), GoombaKoopa},
             {(typeof(Goomba), typeof(Koopa)), GoombaKoopa},
             {(typeof(Goomba), typeof(StompedKoopa)), GoombaStompedKoopa},
             {(typeof(Goomba), typeof(Star)), MoveDynamic},
             //{(typeof(Goomba), typeof(GreenMushroom)), MoveDynamic},
             //{(typeof(Goomba), typeof(RedMushroom)), MoveDynamic},
            

             {(typeof(Koopa), typeof(Koopa)), GoombaKoopa},
             {(typeof(StompedKoopa), typeof(StompedKoopa)), MoveEnemy},
             //might need changes
              {(typeof(Koopa), typeof(StompedKoopa)), KoopaStompedKoopa},
             {(typeof(Koopa), typeof(Star)), MoveDynamic},
             //{(typeof(Koopa), typeof(GreenMushroom)), MoveDynamic},
             //{(typeof(Koopa), typeof(RedMushroom)), MoveDynamic},

             //{(typeof(RedMushroom), typeof(RedMushroom)), MoveDynamic},
             //{(typeof(GreenMushroom), typeof(RedMushroom)), MoveDynamic},
             //{(typeof(GreenMushroom), typeof(GreenMushroom)), MoveDynamic},

        
             { (typeof(FireBall), typeof(Goomba)), FireBallEnemy},
             { (typeof(FireBall), typeof(Koopa)), FireBallEnemy},
             { (typeof(FireBall), typeof(StompedKoopa)), FireBallEnemy},


        };
        private static void StarMario(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            ObjectsManager.Instance.StarMario(((IMario)obj1).ReturnItself());
            ObjectsManager.Instance.Remove(obj2);
        }

        private static void RedMushroom(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            IMario mario = (IMario)obj1;
            if (!(mario is StarMario))
                ObjectsManager.Instance.Decoration(mario ,new FlashingMario(mario.ReturnItself()));   
            ObjectsManager.Instance.Remove(obj2);
            mario.RedMushroom();
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
            if (!(mario is StarMario))
                ObjectsManager.Instance.Decoration(mario, new FlashingMario(mario.ReturnItself()));
            ObjectsManager.Instance.Remove(obj2);
            mario.OnFireFlower();
        }
        private static void Coin(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            IMario mario = (IMario)obj1;
            mario.Coin();
            ObjectsManager.Instance.Remove(obj2);
        }
        private static void FireBallEnemy(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            ObjectsManager.Instance.Remove(obj1);
            ((IEnemy)obj2).Flip();
        }
        
        private static void StarMarioEnemy(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            ((IEnemy)obj2).TakeDamage();
        }
        private static void MoveEnemy(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            //what if the direction is top/bottom
            switch (direction)
            {
                case Direction.left: obj1.MoveRight(); obj2.MoveLeft(); break;
                case Direction.right: obj1.MoveLeft(); obj2.MoveRight(); break;
            }
        }

        private static void MarioEnemy(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            switch (direction)
            {
                case Direction.top:
                    ((IEnemy)obj2).TakeDamage();
                    break;
                default:
                    Type healthState = ((IMario)obj1).HealthState.GetType();
                    if((healthState != typeof(DeadMario)))
                    {
                        if (healthState != typeof(SmallMario))
                            ObjectsManager.Instance.Decoration((IMario)obj1, new FlashingMario((IMario)obj1));
                        ((IMario)obj1).TakeDamage();
                    }
                    break;
            }
        }
        private static void GoombaKoopa(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            switch(direction)   
            {
                case Direction.top:
                    ((IEnemy)obj2).TakeDamage();
                    break;
                case Direction.bottom:
                    ((IEnemy)obj1).TakeDamage();
                    break;
                default:
                    MoveEnemy(obj1, obj2, direction);
                    break;
            }
        }
        private static void MarioStompedKoopa(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            IMario mario = (IMario)obj1;
            switch (direction)
            {
                case Direction.top:
                    //mario.Bump();
                    break;
                case Direction.right:
                    obj2.MoveLeft();
                    break;
                case Direction.left:
                    obj2.MoveRight();
                    break;
                case Direction.bottom:
                   //
                    break;
            }
        }
        //might be used later
        private static void FlashingMarioEnemy(IDynamic obj1, IDynamic obj2, Direction direction)
        {

        }


        private static void GoombaStompedKoopa(IDynamic obj1, IDynamic obj2, Direction direction)
        {

            //code needed when stopmedkoopa is static
            Goomba goomba = (Goomba)obj1;
            goomba.Flip();
        }

        private static void KoopaStompedKoopa(IDynamic obj1, IDynamic obj2, Direction direction)
        {

            //code needed when stopmedkoopa is static
            Koopa koopa = (Koopa)obj1;
            koopa.TakeDamage();
        }

        private static void MoveDynamic(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            switch (direction)
            {
                case Direction.top:
                    obj1.MoveUp();
                    obj2.MoveDown();
                    break;
                case Direction.bottom:
                    obj1.MoveDown();
                    obj2.MoveUp();
                    break;
                case Direction.left:
                    obj1.MoveLeft();
                    obj2.MoveRight();
                    break;
                case Direction.right:
                    obj1.MoveRight();
                    obj2.MoveLeft();
                    break;
            }
        }






    }
}
