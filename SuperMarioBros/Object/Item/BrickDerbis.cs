using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.Items
{
    public enum BrickPosition { leftTop, leftBottom, rightTop, rightBottom }
    public class BrickDerbis : AbstractItem, IItem
    {
        private readonly Dictionary<BrickPosition, Vector2> derbisInfo = new Dictionary<BrickPosition, Vector2>
        {
            { BrickPosition.leftTop, PhysicsConsts.LeftTopBlockDebrisVelocity},
            { BrickPosition.leftBottom, PhysicsConsts.LeftBottomBlockDebrisVelocity},
            { BrickPosition.rightTop,  PhysicsConsts.RightTopBlockDebrisVelocity },
            { BrickPosition.rightBottom,  PhysicsConsts.RightBottomBlockDebrisVelocity}
        };
        private float timer = Timers.BlockDebrisTimeSpan;
        public BrickDerbis(Vector2 location, BrickPosition brickPosition, Type type)
        {
            derbisInfo.TryGetValue(brickPosition, out Vector2 velocity);
            Position = location;
            if(type == typeof(BrickBlock))
                sprite = SpriteFactory.CreateDerbisSprite(brickPosition);
            else
                sprite = SpriteFactory.CreateBlueDerbisSprite(brickPosition);
            Physics = new Physics(velocity, itemGravity, itemWeight);
            ObjState = ObjectState.NonCollidable;
            sprite.SetLayer(itemLayer);
        }

        public override void Update(GameTime gameTime)
        {
            timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            sprite.Update(gameTime);
            Position += Physics.Displacement(gameTime);
            if (timer <= 0)
                ObjState = ObjectState.Destroy;
        }
    }
}
