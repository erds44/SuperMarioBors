using SuperMarioBros.Blocks;
using SuperMarioBros.Blocks.BlockStates;
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
    public static class DynamicAndStaticObjectsHandler
    {

        private delegate void CollisionHandler(IDynamic obj1, IStatic obj2, Direction direction);
        public static void HandleCollision(IDynamic obj1, IStatic obj2, Direction direction)
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
            if (collisionDictionary.TryGetValue((obj1.GetType(),type), out var handle))
            {
                handle(obj1, obj2, direction);
            }
        }

        private static readonly Dictionary<(Type, Type), CollisionHandler> collisionDictionary = new Dictionary<(Type, Type), CollisionHandler>
        {
            { (typeof(Mario), typeof(BrickBlockState)), MarioBrick},
            { (typeof(Mario), typeof(ConcreteBlockState)), MoveDynamic},
            { (typeof(Mario), typeof(QuestionBlockState)), MarioQuestion},
            { (typeof(Mario), typeof(RockBlockState)), MoveDynamic},
            { (typeof(Mario), typeof(UsedBlockState)), MoveDynamic},
            { (typeof(Mario), typeof(HiddenBlockState)), HiddenUsed},
            { (typeof(Mario), typeof(Pipe)), MoveDynamic},

            { (typeof(StarMario), typeof(BrickBlockState)), MarioBrick},
            { (typeof(StarMario), typeof(ConcreteBlockState)), MoveDynamic},
            { (typeof(StarMario), typeof(QuestionBlockState)), MarioQuestion},
            { (typeof(StarMario), typeof(RockBlockState)), MoveDynamic},
            { (typeof(StarMario), typeof(UsedBlockState)), MoveDynamic},
            { (typeof(StarMario), typeof(HiddenBlockState)), HiddenUsed},
            { (typeof(StarMario), typeof(Pipe)), MoveDynamic},

            { (typeof(FlashingMario), typeof(BrickBlockState)), MarioBrick},
            { (typeof(FlashingMario), typeof(ConcreteBlockState)), MoveDynamic},
            { (typeof(FlashingMario), typeof(QuestionBlockState)), MarioQuestion},
            { (typeof(FlashingMario), typeof(RockBlockState)), MoveDynamic},
            { (typeof(FlashingMario), typeof(UsedBlockState)), MoveDynamic},
            { (typeof(FlashingMario), typeof(HiddenBlockState)), HiddenUsed},
            { (typeof(FlashingMario), typeof(Pipe)), MoveDynamic},

            { (typeof(Star), typeof(BrickBlockState)), MoveDynamic},
            { (typeof(Star), typeof(ConcreteBlockState)), MoveDynamic},
            { (typeof(Star), typeof(QuestionBlockState)), MoveDynamic},
            { (typeof(Star), typeof(RockBlockState)), MoveDynamic},
            { (typeof(Star), typeof(UsedBlockState)), MoveDynamic},
            { (typeof(Star), typeof(Pipe)), MoveDynamic},

            { (typeof(Goomba), typeof(RockBlockState)), MoveDynamic},
            { (typeof(Goomba), typeof(BrickBlockState)), MoveDynamic},
            { (typeof(Goomba), typeof(QuestionBlockState)), MoveDynamic},
            { (typeof(Goomba), typeof(UsedBlockState)), MoveDynamic},
            { (typeof(Goomba), typeof(Pipe)), MoveDynamic},

            { (typeof(StompedKoopa), typeof(RockBlockState)), MoveDynamic},
            { (typeof(StompedKoopa), typeof(BrickBlockState)), MoveDynamic},
            { (typeof(StompedKoopa), typeof(QuestionBlockState)), MoveDynamic},
            { (typeof(StompedKoopa), typeof(UsedBlockState)), MoveDynamic},
            { (typeof(StompedKoopa), typeof(Pipe)), MoveDynamic},

            { (typeof(Koopa), typeof(RockBlockState)), MoveDynamic},
            { (typeof(Koopa), typeof(BrickBlockState)), MoveDynamic},
            { (typeof(Koopa), typeof(QuestionBlockState)), MoveDynamic},
            { (typeof(Koopa), typeof(UsedBlockState)), MoveDynamic},
            { (typeof(Koopa), typeof(Pipe)), MoveDynamic},

            { (typeof(FireBall), typeof(BrickBlockState)), FireBallDisappear},
            { (typeof(FireBall), typeof(ConcreteBlockState)), FireBallDisappear},
            { (typeof(FireBall), typeof(QuestionBlockState)), FireBallDisappear},
            { (typeof(FireBall), typeof(RockBlockState)), MoveDynamic},
            { (typeof(FireBall), typeof(UsedBlockState)), FireBallDisappear},
            { (typeof(FireBall), typeof(Pipe)), FireBallDisappear},

            { (typeof(RedMushroom), typeof(RockBlockState)), MoveDynamic},
            { (typeof(RedMushroom), typeof(BrickBlockState)), MoveDynamic},
            { (typeof(RedMushroom), typeof(QuestionBlockState)), MoveDynamic},
            { (typeof(RedMushroom), typeof(UsedBlockState)), MoveDynamic},
            { (typeof(RedMushroom), typeof(Pipe)), MoveDynamic},

            {(typeof(Goomba), typeof(BumpBlockState)), EnemyVsBumpBlock},
            {(typeof(Koopa), typeof(BumpBlockState)), EnemyVsBumpBlock},
            {(typeof(RedMushroom), typeof(BumpBlockState)), ItemVsBumpBlock},
            {(typeof(GreenMushroom), typeof(BumpBlockState)), ItemVsBumpBlock},

            { (typeof(GreenMushroom), typeof(RockBlockState)), MoveDynamic},
            { (typeof(GreenMushroom), typeof(BrickBlockState)), MoveDynamic},
            { (typeof(GreenMushroom), typeof(QuestionBlockState)), MoveDynamic},
            { (typeof(GreenMushroom), typeof(UsedBlockState)), MoveDynamic},
            { (typeof(GreenMushroom), typeof(Pipe)), MoveDynamic},

            { (typeof(Flower), typeof(RockBlockState)), MoveDynamic},
            { (typeof(Flower), typeof(BrickBlockState)), MoveDynamic},
            { (typeof(Flower), typeof(QuestionBlockState)), MoveDynamic},
            { (typeof(Flower), typeof(UsedBlockState)), MoveDynamic},
            { (typeof(Flower), typeof(Pipe)), MoveDynamic},

            

        };
        private static void MarioBrick(IDynamic obj1, IStatic obj2 ,Direction direction)
        {
            IMario mario = (IMario)obj1;
            MoveDynamic(obj1, obj2, direction);

            if(direction == Direction.bottom)
            {
                if (mario.HealthState is SmallMario && obj2 is BrickBlock)
                {
                    ((IBlock)obj2).Bump();
                }
                else {
                    ((IBlock)obj2).Used();
                    ((IBlock)obj2).Bump();
                }
                
            }
        }
        private static void MarioQuestion(IDynamic obj1, IStatic obj2, Direction direction)
        {
            MoveDynamic(obj1, obj2, direction);
            if (direction == Direction.bottom)
            {
                if (obj2 is PowerUpBlock) { ((PowerUpBlock)obj2).IsFlower = !(((IMario)obj1).HealthState is SmallMario); }
                ((IBlock)obj2).Used();
                ((IBlock)obj2).Bump();
            }
        }

        private static void EnemyVsBumpBlock(IDynamic obj1, IStatic obj2, Direction direction)
        {
             ((IEnemy)obj1).Flip();
        }
        private static void ItemVsBumpBlock(IDynamic obj1, IStatic obj2, Direction direction)
        {
            ((IItem)obj1).BumpUp();
            if (obj1.HitBox().Center.X <= obj2.HitBox().Center.X)
                ((IItem)obj1).ChangeDirection();
        }
        private static void MoveDynamic(IDynamic obj1, IStatic obj2, Direction direction)
        {
            switch (direction)
            {
                case Direction.top : obj1.MoveUp(); break;
                case Direction.bottom: obj1.MoveDown(); break;
                case Direction.left: obj1.MoveLeft(); break;
                case Direction.right: obj1.MoveRight(); break;
            }
        }
        private static void HiddenUsed(IDynamic obj1, IStatic obj2, Direction direction)
        {
            if (direction == Direction.bottom)
            {
                if (((IMario)obj1).MarioPhysics.YVelocity < 0)
                {
                    ((IBlock)obj2).Used();
                    MoveDynamic(obj1, obj2, direction);
                }
            }
        }
        private static void FireBallDisappear(IDynamic obj1, IStatic obj2, Direction direction)
        {
            obj1.IsInvalid = true; 
        }

    }
}
