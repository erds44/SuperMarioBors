using Microsoft.Xna.Framework;
using SuperMarioBros.Physicses;
using System;

namespace SuperMarioBros.Items
{

    public class BigCoin : AbstractItem, IItem
    {
        private new Vector2 initialVelocity = new Vector2(0, 0);
        private new float itemGravity = 0f;
        public Action<Vector2> CoinCollectedEvent;
        public BigCoin(Vector2 location)
        {
            Position = location;
            base.Initialize();
            Physics = new Physics(initialVelocity, itemGravity, itemWeight);
            ObjState = ObjectState.Normal;
        }

    }

}
