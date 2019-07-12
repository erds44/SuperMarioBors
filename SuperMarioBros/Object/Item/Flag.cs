using Microsoft.Xna.Framework;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;
using System;

namespace SuperMarioBros.Items
{
    public class Flag : AbstractItem, IItem
    {
        public event Action MarioJumpingOffFlagEvent;
        private readonly float flagLowestPoistion;
        private bool marioJumpFlag;
        public Flag(Vector2 location)
        {
            Position = location;
            ObjState = ObjectState.Normal;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(Layers.FlagLayer);
            Physics = new Physics(Vector2.Zero, PhysicsConsts.FlagGravity,PhysicsConsts.FlagWeight);
            flagLowestPoistion = location.Y + Locations.FlagBottomOffset;
            marioJumpFlag = false;

        }
        public override void Update(GameTime gameTime)
        {
            Position += Physics.Displacement(gameTime);
            if(Position.Y >= flagLowestPoistion && !marioJumpFlag)
            {
                MarioJumpingOffFlagEvent?.Invoke();
                marioJumpFlag = true;
            }
        }
        public void Sliding(Vector2 position) //mathing the signiture only, since socrebaod use the same event as well
        {
            Physics.Velocity = PhysicsConsts.FlagVelocity;
            Physics.ApplyGravity();
        }
    }
}

