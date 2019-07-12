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
        private readonly Dictionary<(Type, BrickPosition), string> debrisSpriteInfo = new Dictionary<(Type, BrickPosition), string>
        {
            {(typeof(BrickBlock),BrickPosition.leftTop),StringConsts.LeftTopBrickDebris },
            {(typeof(BrickBlock),BrickPosition.leftBottom),StringConsts.LeftBottomBrickDebris },
            {(typeof(BrickBlock),BrickPosition.rightTop),StringConsts.RightTopBrickDebris },
            {(typeof(BrickBlock),BrickPosition.rightBottom),StringConsts.RightBottomBrickDebris },

            {(typeof(BlueBrickBlock),BrickPosition.leftTop),StringConsts.LeftTopBlueBrickDebris },
            {(typeof(BlueBrickBlock),BrickPosition.leftBottom),StringConsts.LeftBottomBlueBrickDebris },
            {(typeof(BlueBrickBlock),BrickPosition.rightTop),StringConsts.RightTopBlueBrickDebris },
            {(typeof(BlueBrickBlock),BrickPosition.rightBottom),StringConsts.RightBottomBlueBrickDebris }
        };
        private float timer = Timers.BlockDebrisTimeSpan;
        public BrickDerbis(Vector2 location, BrickPosition brickPosition, Type type)
        {
            derbisInfo.TryGetValue(brickPosition, out Vector2 velocity);
            Position = location;
            debrisSpriteInfo.TryGetValue((type, brickPosition), out string spriteName);
            sprite = SpriteFactory.CreateSprite(spriteName);
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
