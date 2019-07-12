using Microsoft.Xna.Framework;
using SuperMarioBros.Physicses;
using SuperMarioBros.Utility;
using System;

namespace SuperMarioBros.Items
{

    public class BigCoin : AbstractItem, IItem
    {
        public Action<Vector2> CoinCollectedEvent;
        public BigCoin(Vector2 location)
        {
            Position = location;
            base.Initialize();
            Physics = new Physics(PhysicsConsts.BigCoinInitialVelocity, PhysicsConsts.BigCoinGravity, itemWeight);
            ObjState = ObjectState.Normal;
        }

    }

}
