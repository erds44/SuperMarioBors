using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Goombas;
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
    public class DynamicAndStaticObjectsHandler
    {
        private MarioGame game;
        private ObjectsManager objManager { get => game.ObjectsManager; }
        private readonly Dictionary<(Type, Type), CollisionHandler> collisionDictionary;
        public DynamicAndStaticObjectsHandler(MarioGame game)
        {
            this.game = game;
            collisionDictionary = new Dictionary<(Type, Type), CollisionHandler>{
                { (typeof(Mario), typeof(BrickBlockState)), MarioBrick},
                { (typeof(Mario), typeof(ConcreteBlockState)), MoveDynamic},
                { (typeof(Mario), typeof(QuestionBlockState)), MarioQuestion},
                { (typeof(Mario), typeof(RockBlockState)), MoveDynamic},
                { (typeof(Mario), typeof(UsedBlockState)), MoveDynamic},
                { (typeof(Mario), typeof(HiddenBlockState)), MarioHidden},
                { (typeof(Mario), typeof(Pipe)), MoveDynamic},
                { (typeof(Mario), typeof(HighPipe)), MoveDynamic},
                { (typeof(Mario), typeof(MiddlePipe)), MoveDynamic},

                { (typeof(StarMario), typeof(BrickBlockState)), MarioBrick},
                { (typeof(StarMario), typeof(ConcreteBlockState)), MoveDynamic},
                { (typeof(StarMario), typeof(QuestionBlockState)), MarioQuestion},
                { (typeof(StarMario), typeof(RockBlockState)), MoveDynamic},
                { (typeof(StarMario), typeof(UsedBlockState)), MoveDynamic},
                { (typeof(StarMario), typeof(HiddenBlockState)), MarioHidden},
                { (typeof(StarMario), typeof(HighPipe)), MoveDynamic},
                { (typeof(StarMario), typeof(MiddlePipe)), MoveDynamic},
                { (typeof(StarMario), typeof(Pipe)), MoveDynamic},

                { (typeof(FlashingMario), typeof(BrickBlockState)), MarioBrick},
                { (typeof(FlashingMario), typeof(ConcreteBlockState)), MoveDynamic},
                { (typeof(FlashingMario), typeof(QuestionBlockState)), MarioQuestion},
                { (typeof(FlashingMario), typeof(RockBlockState)), MoveDynamic},
                { (typeof(FlashingMario), typeof(UsedBlockState)), MoveDynamic},
                { (typeof(FlashingMario), typeof(HiddenBlockState)), MarioHidden},
                { (typeof(FlashingMario), typeof(Pipe)), MoveDynamic},
                { (typeof(FlashingMario), typeof(HighPipe)), MoveDynamic},
                { (typeof(FlashingMario), typeof(MiddlePipe)), MoveDynamic},

                { (typeof(Star), typeof(BrickBlockState)), MoveDynamic},
                { (typeof(Star), typeof(ConcreteBlockState)), MoveDynamic},
                { (typeof(Star), typeof(QuestionBlockState)), MoveDynamic},
                { (typeof(Star), typeof(RockBlockState)), MoveDynamic},
                { (typeof(Star), typeof(UsedBlockState)), MoveDynamic},
                { (typeof(Star), typeof(Pipe)), MoveDynamic},
                { (typeof(Star), typeof(MiddlePipe)), MoveDynamic},
                { (typeof(Star), typeof(HighPipe)), MoveDynamic},

                { (typeof(Goomba), typeof(RockBlockState)), MoveDynamic},
                { (typeof(Goomba), typeof(BrickBlockState)), MoveDynamic},
                { (typeof(Goomba), typeof(QuestionBlockState)), MoveDynamic},
                { (typeof(Goomba), typeof(UsedBlockState)), MoveDynamic},
                { (typeof(Goomba), typeof(Pipe)), MoveDynamic},
                { (typeof(Goomba), typeof(HighPipe)), MoveDynamic},
                { (typeof(Goomba), typeof(MiddlePipe)), MoveDynamic},
                { (typeof(Goomba), typeof(DisappearBlockState)), BrickVsEnemy},

                { (typeof(StompedGoomba), typeof(RockBlockState)), MoveDynamic},
                { (typeof(StompedGoomba), typeof(BrickBlockState)), MoveDynamic},
                { (typeof(StompedGoomba), typeof(QuestionBlockState)), MoveDynamic},
                { (typeof(StompedGoomba), typeof(UsedBlockState)), MoveDynamic},
                { (typeof(StompedGoomba), typeof(Pipe)), MoveDynamic},
                { (typeof(StompedGoomba), typeof(HighPipe)), MoveDynamic},
                { (typeof(StompedGoomba), typeof(MiddlePipe)), MoveDynamic},

                { (typeof(StompedKoopa), typeof(RockBlockState)), MoveDynamic},
                { (typeof(StompedKoopa), typeof(BrickBlockState)), MoveDynamic},
                { (typeof(StompedKoopa), typeof(QuestionBlockState)), MoveDynamic},
                { (typeof(StompedKoopa), typeof(UsedBlockState)), MoveDynamic},
                { (typeof(StompedKoopa), typeof(Pipe)), MoveDynamic},
                { (typeof(StompedKoopa), typeof(HighPipe)), MoveDynamic},
                { (typeof(StompedKoopa), typeof(MiddlePipe)), MoveDynamic},

                { (typeof(Koopa), typeof(RockBlockState)), MoveDynamic},
                { (typeof(Koopa), typeof(BrickBlockState)), MoveDynamic},
                { (typeof(Koopa), typeof(QuestionBlockState)), MoveDynamic},
                { (typeof(Koopa), typeof(UsedBlockState)), MoveDynamic},
                { (typeof(Koopa), typeof(Pipe)), MoveDynamic},
                { (typeof(Koopa), typeof(MiddlePipe)), MoveDynamic},
                { (typeof(Koopa), typeof(HighPipe)), MoveDynamic},
                { (typeof(Koopa), typeof(DisappearBlockState)), BrickVsEnemy},

                { (typeof(FireBall), typeof(BrickBlockState)), FireBallDisappear},
                { (typeof(FireBall), typeof(ConcreteBlockState)), FireBallDisappear},
                { (typeof(FireBall), typeof(QuestionBlockState)), FireBallDisappear},
                { (typeof(FireBall), typeof(RockBlockState)), MoveDynamic},
                { (typeof(FireBall), typeof(UsedBlockState)), FireBallDisappear},
                { (typeof(FireBall), typeof(Pipe)), FireBallDisappear},
                { (typeof(FireBall), typeof(HighPipe)), FireBallDisappear},
                { (typeof(FireBall), typeof(MiddlePipe)), FireBallDisappear},

                { (typeof(RedMushroom), typeof(RockBlockState)), MoveDynamic},
                { (typeof(RedMushroom), typeof(ConcreteBlockState)), MoveDynamic},
                { (typeof(RedMushroom), typeof(BrickBlockState)), MoveDynamic},
                { (typeof(RedMushroom), typeof(QuestionBlockState)), MoveDynamic},
                { (typeof(RedMushroom), typeof(UsedBlockState)), MoveDynamic},
                { (typeof(RedMushroom), typeof(Pipe)), MoveDynamic},
                { (typeof(RedMushroom), typeof(HighPipe)), MoveDynamic},
                { (typeof(RedMushroom), typeof(MiddlePipe)), MoveDynamic},

                {(typeof(Goomba), typeof(BumpBlockState)), EnemyVsBumpBlock},
                {(typeof(Koopa), typeof(BumpBlockState)), EnemyVsBumpBlock},
                {(typeof(RedMushroom), typeof(BumpBlockState)), ItemVsBumpBlock},
                {(typeof(GreenMushroom), typeof(BumpBlockState)), ItemVsBumpBlock},

                { (typeof(GreenMushroom), typeof(RockBlockState)), MoveDynamic},
                { (typeof(GreenMushroom), typeof(ConcreteBlockState)), MoveDynamic},
                { (typeof(GreenMushroom), typeof(BrickBlockState)), MoveDynamic},
                { (typeof(GreenMushroom), typeof(QuestionBlockState)), MoveDynamic},
                { (typeof(GreenMushroom), typeof(UsedBlockState)), MoveDynamic},
                { (typeof(GreenMushroom), typeof(Pipe)), MoveDynamic},
                { (typeof(GreenMushroom), typeof(HighPipe)), MoveDynamic},
                { (typeof(GreenMushroom), typeof(MiddlePipe)), MoveDynamic},

                { (typeof(Flower), typeof(RockBlockState)), MoveDynamic},
                { (typeof(Flower), typeof(BrickBlockState)), MoveDynamic},
                { (typeof(Flower), typeof(QuestionBlockState)), MoveDynamic},
                { (typeof(Flower), typeof(UsedBlockState)), MoveDynamic},
                { (typeof(Flower), typeof(Pipe)), MoveDynamic},
                { (typeof(Flower), typeof(MiddlePipe)), MoveDynamic},
                { (typeof(Flower), typeof(HighPipe)), MoveDynamic},
            };
        }

        public void HandleCollision(IDynamic obj1, IStatic obj2, Direction direction)
        {
            Type type;
            if (obj2 is IBlock)
            {
                type = ((IBlock)obj2).State.GetType();

            }
            else
            {
                type = obj2.GetType();
            }
            if (collisionDictionary.TryGetValue((obj1.GetType(), type), out var handle))
            {
                handle(obj1, obj2, direction);
            }
        }

        private delegate void CollisionHandler(IDynamic obj1, IStatic obj2, Direction direction);

        private void MoveDynamic(IDynamic obj1, IStatic obj2, Direction direction)
        {
            switch (direction)
            {
                case Direction.top: obj1.MoveUp(); break;
                case Direction.bottom: obj1.MoveDown(); break;
                case Direction.left: obj1.MoveLeft(); break;
                case Direction.right: obj1.MoveRight(); break;
            }
        }

        private void BrickVsEnemy(IDynamic obj1, IStatic obj2, Direction direction)
        {
            if(direction == Direction.top)
            {
                ((IEnemy)obj1).Flip();
                obj2.ObjState = ObjectState.Destroy;;
            }
        }
        private void EnemyVsBumpBlock(IDynamic obj1, IStatic obj2, Direction direction)
        {
            /*            if (obj1 is Koopa)
                        {
                            obj1.ObjState = ObjectState.Destroy;;
                            game.ObjectsManagerAddNonCollidable(new FlippedKoopa(new StompedKoopa(obj1.Position)));
                        }
                        else
                        {*/
            ((IEnemy)obj1).Flip();
            //}
        }
        private void ItemVsBumpBlock(IDynamic obj1, IStatic obj2, Direction direction)
        {
            ((IItem)obj1).BumpUp();
            if (obj1.HitBox().Center.X <= obj2.HitBox().Center.X)
                ((IItem)obj1).ChangeDirection();
        }


        private void MarioBrick(IDynamic obj1, IStatic obj2 ,Direction direction)
        {
            IMario mario = (IMario)obj1;
            IBlock block = (IBlock)obj2;
            MoveDynamic(obj1, obj2, direction);
            
            if (direction == Direction.bottom)
            {
                block.Bump();
                if (block is ItemBrickBlock)
                {
                    ItemBrickBlock itemBrick = (ItemBrickBlock)obj2;
                    if (itemBrick.ItemType == null)
                        objManager.CreateNonCollidableObject(((IMario)obj1).HealthState is SmallMario ? typeof(RedMushroom) : typeof(Flower), block.Position);
                    else
                        objManager.CreateNonCollidableObject(itemBrick.ItemType, block.Position);
                    itemBrick.Used();
                }
                else // BrickBlock
                {
                    if (mario.HealthState is SmallMario) return;
                    block.Used();
                    CreateDerbis(block.Position);
                }
/*                if (mario.HealthState is SmallMario && obj2 is BrickBlock)
                {
                    ((IBlock)obj2).Bump();
                }
                else {
                    ((IBlock)obj2).Used();
                    if(obj2 is ItemBrickBlock)
                        ((IBlock)obj2).Bump();
                    else
                        CreateDerbis(obj2.Position);
                }*/
                
            }
        }
        private void MarioQuestion(IDynamic obj1, IStatic obj2, Direction direction)
        {
            if (direction == Direction.bottom)
            {
                MoveDynamic(obj1, obj2, direction);
                ((IBlock)obj2).Bump();
                var block = (QuestionBlock)obj2;
                if (block.ItemType == null)
                    objManager.CreateNonCollidableObject(((IMario)obj1).HealthState is SmallMario ? typeof(RedMushroom) : typeof(Flower), block.Position);
                else
                    objManager.CreateNonCollidableObject(block.ItemType, block.Position);
                block.Used();
            }
        }
        private void MarioHidden(IDynamic obj1, IStatic obj2, Direction direction)
        {
            if (direction == Direction.bottom && ((IMario)obj1).MarioPhysics.YVelocity < 0)
            {
                var block = (HiddenBlock)obj2;
                if (block.ItemType == null)
                    objManager.CreateNonCollidableObject(((IMario)obj1).HealthState is SmallMario ? typeof(RedMushroom) : typeof(Flower), block.Position);
                else
                    objManager.CreateNonCollidableObject(block.ItemType, block.Position);
                block.Used();
                MoveDynamic(obj1, obj2, direction);
            }
        }

        private void FireBallDisappear(IDynamic obj1, IStatic obj2, Direction direction)
        {
            obj1.ObjState = ObjectState.Destroy;
        }



        private void CreateDerbis(Vector2 position)
        {
            game.ObjectsManager.AddObject(new BrickDerbis(position, BrickPosition.leftTop));
            game.ObjectsManager.AddObject(new BrickDerbis(position, BrickPosition.leftBottom));
            game.ObjectsManager.AddObject(new BrickDerbis(position, BrickPosition.rightTop));
            game.ObjectsManager.AddObject(new BrickDerbis(position, BrickPosition.rightBottom));
        }

    }
}
