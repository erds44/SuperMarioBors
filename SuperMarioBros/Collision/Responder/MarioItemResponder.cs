using Microsoft.Xna.Framework;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Collisions
{
    public class MarioItemResponder : MarioItemCollisionHandler, ICollisionResponder
    {
        private delegate void MarioItemHandler(IMario mario, IItem item);
        public void HandleCollision(IObject mover, IObject target, Direction direction)
        {
            IMario mario = (IMario)mover;
            IItem item = (IItem)target;
            if (handlerDictionary.ContainsKey(target.GetType()))
                handlerDictionary[target.GetType()](mario, item);
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
    }
}
