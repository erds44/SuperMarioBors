using Microsoft.Xna.Framework;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Items
{
    
        public class BigCoin : AbstractItem, IItem
        {
            private new Vector2 initialVelocity = new Vector2(0, 0);
            private new float itemGravity = 0f;
            public BigCoin(Vector2 location)
            {
                    Position = location;
                    base.Initialize();
                    Physics = new Physics(initialVelocity, itemGravity, itemWeight);
                     ObjState = ObjectState.Normal;
            }
        }
    
}
