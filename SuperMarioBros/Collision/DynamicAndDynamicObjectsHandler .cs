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
    public enum Direction { left, right, top, bottom, none }
    public class DynamicAndDynamicObjectsHandler
    {
        private readonly MarioGame game;
        private ObjectsManager objManager { get => game.ObjectsManager; }

        private readonly Dictionary<(Type, Type), CollisionHandler> collisionDictionary;

        public DynamicAndDynamicObjectsHandler(MarioGame game)
        {/* Dictionary for all possible collision cases */
            this.game = game;
            collisionDictionary = new Dictionary<(Type, Type), CollisionHandler>{
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
                 {(typeof(StompedKoopa), typeof(FireBall)), FireBallVSEnemy},

                 {(typeof(FireBall), typeof(Goomba)), FireBallVSEnemy},
                 {(typeof(FireBall), typeof(Koopa)), FireBallVSEnemy},
                 {(typeof(FireBall), typeof(StompedKoopa)), FireBallVSEnemy},
            };
        }
        public void HandleCollision(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            if (collisionDictionary.TryGetValue((obj1.GetType(), obj2.GetType()), out var handle))
                //if(!(obj1.GetType() == typeof(Mario)&&((IMario)obj1).HealthState.GetType() == typeof(DeadMario)))
                handle(obj1, obj2, direction);
        }

        private delegate void CollisionHandler(IDynamic obj1, IDynamic obj2, Direction direction);
        private void StarMario(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            //ObjectsManager.Instance.StarMario(((IMario)obj1).ReturnItself());
            objManager.StarMario((IMario)obj1);
            obj2.ObjState = ObjectState.Destroy;  //Delete flag
        }

        private void RedMushroom(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            IMario mario = (IMario)obj1;
            mario.RedMushroom(); 
            objManager.FlashingMario(mario);
            obj2.ObjState = ObjectState.Destroy;
        }
        private void GreenMushroom(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            ((IMario)obj1).GreenMushroom();
            obj2.ObjState = ObjectState.Destroy;
        }
        private void FireFlower(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            IMario mario = (IMario)obj1;
            mario.OnFireFlower();
            objManager.FlashingMario(mario);
            obj2.ObjState = ObjectState.Destroy;
        }

        private void Coin(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            ((IMario)obj1).Coin();
            obj2.ObjState = ObjectState.Destroy;
        }

        private void FireBallVSEnemy(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            if (obj1 is FireBall)
            {
                obj1.ObjState = ObjectState.Destroy;
                ((IEnemy)obj2).Flip();
            }
            else
            {
                obj2.ObjState = ObjectState.Destroy;
                ((IEnemy)obj1).Flip();
            }
        }

        private void StarMarioEnemy(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            ((IEnemy)obj2).Flip();
        }
        private void MoveEnemy(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            switch (direction)
            {
                case Direction.left: obj1.MoveRight(); obj2.MoveLeft(); break;
                case Direction.right: obj1.MoveLeft(); obj2.MoveRight(); break;
                case Direction.top: ((IEnemy)obj1).BumpUp(); obj2.TakeDamage(); break;
            }
        }

        private void MarioEnemy(IDynamic obj1, IDynamic obj2, Direction direction)
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
                        var mario = (IMario)obj1;
                        if (healthState != typeof(SmallMario))
                            objManager.FlashingMario(mario);
                        mario.TakeDamage();
                    }
                    break;
            }
        }
        private void MarioVsStompedKoopa(IDynamic obj1, IDynamic obj2, Direction direction)
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
                            var mario = (IMario)obj1;
                            if (!(state is SmallMario))
                                objManager.FlashingMario(mario);
                            mario.TakeDamage();
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
                            var mario = (IMario)obj1;
                            if (!(state is SmallMario))
                                objManager.FlashingMario(mario);
                            mario.TakeDamage();
                        }
                    }
                    else
                        obj2.MoveRight();
                    break;
            }
        }
        private void StompedKoopaDealDamage(IDynamic obj1, IDynamic obj2, Direction direction)
        {
            if (obj1 is StompedKoopa) ((IEnemy)obj2).Flip(); else ((IEnemy)obj1).Flip();
        }
    }
}
