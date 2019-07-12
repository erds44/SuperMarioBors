using Microsoft.Xna.Framework;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Items;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;
using System.Collections.Generic;

namespace SuperMarioBros.Marios
{
    public enum FireBallDirection {left, right}
    public class FireBall : AbstractItem
    {
        private readonly Dictionary<FireBallDirection, Vector2> velocityDictionary = new Dictionary<FireBallDirection, Vector2>
        {
            {FireBallDirection.left, PhysicsConsts.LeftFireBallVelocity},
            {FireBallDirection.right,  PhysicsConsts.RightFireBallVelocity}
        };
        public bool Explosion { get; private set; }
        private float explosionTimer = Timers.FireBallExplosionTimeSpan;
        private int fireBallOffSet = Locations.FireBallOffSet;
        public FireBall(Vector2 position, FireBallDirection direction)
        {
            Position = position;
            velocityDictionary.TryGetValue(direction, out Vector2 velocity);
            Physics = new Physics(velocity, PhysicsConsts.FireBallGravity, PhysicsConsts.FireBallWeight);
            Physics.ApplyGravity();
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            Explosion = false;
            AudioFactory.Instance.CreateSound(Strings.FireBall).Play();
        }

        public override Rectangle ItemHitBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y - fireBallOffSet, fireBallOffSet, fireBallOffSet);
        }

        public override void Destroy() { }
        public void FireExplosion()
        {
            AudioFactory.Instance.CreateSound(Strings.Kick).Play();
            sprite = SpriteFactory.CreateSprite(nameof(FireExplosion));
            sprite.SetLayer(itemLayer);
            Position += Locations.FireBallExplosionOffSet;
            ObjState = ObjectState.NonCollidable;
            Explosion = true;
        }
        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            if (Explosion)
            {           
                explosionTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (explosionTimer <= 0)
                    ObjState = ObjectState.Destroy;
            }else
                Position += Physics.Displacement(gameTime);
        }
    }
}
