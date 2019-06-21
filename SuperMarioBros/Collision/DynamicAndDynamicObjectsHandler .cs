using SuperMarioBros.Blocks;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Goombas;
using SuperMarioBros.Goombas.GoombaStates;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Items;
using SuperMarioBros.Koopas;
using SuperMarioBros.Managers;
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
                //if(!(obj1.GetType() == typeof(Mario)&&((IMario)obj1).HealthState.GetType() == typeof(DeadMario)))
                handle(obj1, obj2, direction);
        }

        /* Dictionary for all possible collision cases */
        private static readonly Dictionary<(Type, Type), CollisionHandler> collisionDictionary = new Dictionary<(Type, Type), CollisionHandler>
        {
             /*item*/
             {(typeof(Mario), typeof(Star)), StarMario},
             {(typeof(Mario), typeof(RedMushroom)), RedMushroom},
             {(typeof(Mario), typeof(GreenMushroom)), GreenMushroom},
             {(typeof(Mario), typeof(Flower)), FireFlower},
             {(typeof(Mario), typeof(Coin)), Coin},
             /*Enemy*/
             {(typeof(Mario), typeof(Goomba)), MarioEnemy},
             {(typeof(Mario), typeof(Koopa)), MarioEnemy},
             {(typeof(Mario), typeof(StompedKoopa)), MarioVsStompedKoopa},

             {(typeof(StarMario), typeof(Star)), StarMario},
             {(typeof(StarMario), typeof(RedMushroom)), RedMushroom},
             {(typeof(StarMario), typeof(GreenMushroom)), GreenMushroom},
             {(typeof(StarMario), typeof(Flower)), FireFlower},
             {(typeof(StarMario), typeof(Coin)), Coin},
             {(typeof(StarMario), typeof(Goomba)), StarMarioEnemy},
             {(typeof(StarMario), typeof(Koopa)), StarMarioEnemy},
             {(typeof(StarMario), typeof(StompedKoopa)), StarMarioEnemy},

             /* Flashing Mario will pass enemy */
             {(typeof(FlashingMario), typeof(Star)), StarMario},
             {(typeof(FlashingMario), typeof(RedMushroom)), RedMushroom},
             {(typeof(FlashingMario), typeof(GreenMushroom)), GreenMushroom},
             {(typeof(FlashingMario), typeof(Flower)), FireFlower},
             {(typeof(FlashingMario), typeof(Coin)), Coin},

             /* Enemy will pass item */
             {(typeof(Goomba), typeof(Goomba)), MoveEnemy},
             {(typeof(Goomba), typeof(Koopa)), MoveEnemy},
             {(typeof(Goomba), typeof(StompedKoopa)), StompedKoopaDealDamage},
             {(typeof(Goomba), typeof(FireBall)), FireBallVSEnemy},

             {(typeof(Koopa), typeof(Koopa)), MoveEnemy},
             {(typeof(Koopa), typeof(Goomba)), MoveEnemy},
             //{(typeof(Koopa), typeof(StompedKoopa)), StompedKoopaDealDamage}, To be fixed
             {(typeof(Koopa), typeof(FireBall)), FireBallVSEnemy},

             {(typeof(StompedKoopa), typeof(Goomba)), StompedKoopaDealDamage},
             //{(typeof(StompedKoopa), typeof(Koopa)), StompedKoopaDealDamage},
             //{(typeof(StompedKoopa), typeof(StompedKoopa)), MoveDynamic}, Dont consider for now
             {(typeof(StompedGoomba), typeof(FireBall)), FireBallVSEnemy},

             {(typeof(FireBall), typeof(Goomba)), FireBallVSEnemy},
             {(typeof(FireBall), typeof(Koopa)), FireBallVSEnemy},
             {(typeof(FireBall), typeof(StompedKoopa)), FireBallVSEnemy},
        };
        private static void StarMario(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            ObjectsManager.Instance.StarMario(((IMario)obj1).ReturnItself());
            obj2.IsInvalid = true;  //Delete flag
        }

        private static void RedMushroom(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            IMario mario = (IMario)obj1;
            if (!(mario is StarMario)) /* avoid double decoration */
                ObjectsManager.Instance.Decoration(mario, new FlashingMario(mario.ReturnItself()));
            obj2.IsInvalid = true;
            mario.RedMushroom();
        }
        private static void GreenMushroom(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            ((IMario)obj1).GreenMushroom();
            obj2.IsInvalid = true;
        }
        private static void FireFlower(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            IMario mario = (IMario)obj1;
            if (!(mario is StarMario))
                ObjectsManager.Instance.Decoration(mario, new FlashingMario(mario.ReturnItself()));
            obj2.IsInvalid = true;
            mario.OnFireFlower();
        }
        private static void Coin(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            ((IMario)obj1).Coin();
            obj2.IsInvalid = true;
        }
        private static void FireBallVSEnemy(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            if (obj1 is FireBall)
            {
                obj1.IsInvalid = true;
                ((IEnemy)obj2).Flip();
            }
            else
            {
                obj2.IsInvalid = true;
                ((IEnemy)obj1).Flip();
            }
        }

        private static void StarMarioEnemy(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            ((IEnemy)obj2).Flip();
        }
        private static void MoveEnemy(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            switch (direction)
            {
                case Direction.left: obj1.MoveRight(); obj2.MoveLeft(); break;
                case Direction.right: obj1.MoveLeft(); obj2.MoveRight(); break;
                case Direction.top: ((IEnemy)obj1).BumpUp(); obj2.TakeDamage(); break;
            }
        }

        private static void MarioEnemy(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            switch (direction)
            {
                case Direction.top:
                    ((IMario)obj1).BumpUp();
                    ((IEnemy)obj2).TakeDamage();
                    break;
                default:
                    Type healthState = ((IMario)obj1).HealthState.GetType();
                    if ((healthState != typeof(DeadMario)))
                    {
                        if (healthState != typeof(SmallMario))
                            ObjectsManager.Instance.Decoration((IMario)obj1, new FlashingMario((IMario)obj1));
                        ((IMario)obj1).TakeDamage();
                    }
                    break;
            }
        }
        private static void MarioVsStompedKoopa(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            switch (direction)
            {

                case Direction.top:
                    if (((StompedKoopa)obj2).State is IdleEnemyState && ((IMario)obj1).MarioPhysics.YVelocity >= 100)
                    {
                        if (obj1.HitBox().Center.X <= obj2.HitBox().Center.X)
                            obj2.MoveRight();
                        else
                            obj2.MoveLeft();
                    }
                    else
                    {
                        ((StompedKoopa)obj2).Idle();
                        obj1.MoveUp();
                    }
                    break;
                case Direction.right:
                    if (((StompedKoopa)obj2).DealDamge)
                    {
                        IMarioHealthState state = ((IMario)obj1).HealthState;
                        if (!(state is DeadMario))
                        {
                            if (!(state is SmallMario))
                                ObjectsManager.Instance.Decoration((IMario)obj1, new FlashingMario(((IMario)obj1)));
                            ((IMario)obj1).TakeDamage();
                        }
                    }
                    else
                        obj2.MoveLeft();
                    break;
                case Direction.left:
                    if (((StompedKoopa)obj2).DealDamge)
                    {
                        IMarioHealthState state = ((IMario)obj1).HealthState;
                        if (!(state is DeadMario))
                        {
                            if (!(state is SmallMario))
                                ObjectsManager.Instance.Decoration((IMario)obj1, new FlashingMario(((IMario)obj1)));
                            ((IMario)obj1).TakeDamage();
                        }
                    }
                    else
                        obj2.MoveRight();
                    break;
            }
        }
        private static void StompedKoopaDealDamage(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            if (obj1 is StompedKoopa) ((IEnemy)obj2).Flip(); else ((IEnemy)obj1).Flip();
        }

    }
}
