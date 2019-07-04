using Microsoft.Xna.Framework;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class MarioItemResponse : GeneralResponse
    {
        private readonly IMario mario;
        private readonly IItem item;
        private readonly Direction direction;
        private static readonly Vector2 marioFlagOffset = new Vector2(14, 0);
        private delegate void MarioItemHandler(IMario mario, IItem item);

        public MarioItemResponse(IObject mario, IObject item , Direction direction)
        {
            this.mario = (IMario)mario;
            this.item = (IItem)item;
            this.direction = direction;
        }
        public override void HandleCollision()
        {
            if (direction != Direction.none)
            {
                handlerDictionary.TryGetValue(item.GetType(), out var handler);
                handler?.Invoke(mario, item);
            }
        }
        private readonly Dictionary<Type, MarioItemHandler> handlerDictionary = new Dictionary<Type, MarioItemHandler>
        {
            {typeof(Star), TakeStar},
            {typeof(BigCoin), TakeBigCoin},
            {typeof(RedMushroom),TakeRedMushroom},
            {typeof(Flower), TakeFlower},
            {typeof(GreenMushroom), TakeGreenMushroom},
            {typeof(Coin), TakeCoin},
            {typeof(FlagPole), SlidingFlagPole},
            {typeof(Castle), EnterCastle } 
        };

        private static void EnterCastle(IMario mario, IItem item)
        {
            mario.ObjState = ObjectState.Destroy;
        }

        private static void SlidingFlagPole(IMario mario, IItem item)
        {
            mario.SlidingFlagPole();
            if(mario.Position.Y <= 88)
                mario.Position = new Vector2(mario.Position.X, 88);
            mario.Position += marioFlagOffset;
            item.ObjState = ObjectState.NonCollidable;
            MarioGame.Instance.ChangeToFlagPoleState();
        }

        private static void TakeStar(IMario mario, IItem item)
        {
            mario.TakeStar();
            item.ObjState = ObjectState.Destroy;
        }
        private static void TakeRedMushroom(IMario mario, IItem item) 
        {
            mario.TakeRedMushroom();
            item.ObjState = ObjectState.Destroy;
        }
        private static void TakeFlower(IMario mario, IItem item)
        {
            mario.TakeFlower();
            item.ObjState = ObjectState.Destroy;
        }
        private static void TakeGreenMushroom(IMario mario, IItem item)
        {
            mario.TakeGreenMushroom();
            item.ObjState = ObjectState.Destroy;
        }
        private static void TakeCoin(IMario mario, IItem item)
        {
            //Do Nothing for Mario Right now, should be scroe board
            item.ObjState = ObjectState.Destroy;
        }

        private static void TakeBigCoin(IMario mario, IItem item)
        {
            //Do Nothing for Mario Right now, should be scroe board
            item.ObjState = ObjectState.Destroy;
        }
    }
}
