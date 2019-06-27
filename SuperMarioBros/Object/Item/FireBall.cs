using Microsoft.Xna.Framework;
using SuperMarioBros.Items;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using System.Collections.Generic;

namespace SuperMarioBros.Marios
{
    public enum fireBallDirection {left, right}
    public class FireBall : AbstractItem
    {
        private Dictionary<fireBallDirection, Vector2> velocityDictionary = new Dictionary<fireBallDirection, Vector2>
        {
            {fireBallDirection.left, new Vector2(-300, 50)},
            {fireBallDirection.right, new Vector2(300, 50)}
        };
        private float gravity = 600f;
        private float weight = 20f;
        public bool Explosion { get; private set; }
        private float explosionTimer = 0.2f;
        private Vector2 explosionOffSet = new Vector2(-16, 0);
        public FireBall(Vector2 position, fireBallDirection direction)
        {
            Position = position;
            Vector2 velocity = Vector2.Zero;
            velocityDictionary.TryGetValue(direction, out velocity);
            Physics = new Physics(velocity, gravity, weight);
            Physics.ApplyGravity();
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            Explosion = false;
        }

        public override Rectangle HitBox()
        {
            return new Rectangle((int)Position.X, (int)Position.Y - 16, 16, 16);
        }

        public override void Destroy()
        {
            // Do Nothing
        }
        public void FireExplosion()
        {
            sprite = SpriteFactory.CreateSprite(nameof(FireExplosion));
            Position += explosionOffSet;
            Explosion = true;
        }
        public override void Update(GameTime gameTime)
        {
            if (Explosion)
            {
                sprite.Update();
                explosionTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (explosionTimer <= 0)
                    ObjState = ObjectState.Destroy;
            }
            else
                base.Update(gameTime);
        }
    }
}
