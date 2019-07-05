using Microsoft.Xna.Framework;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Items;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using System.Collections.Generic;

namespace SuperMarioBros.Marios
{
    public enum FireBallDirection {left, right}
    public class FireBall : AbstractItem
    {
        private readonly Dictionary<FireBallDirection, Vector2> velocityDictionary = new Dictionary<FireBallDirection, Vector2>
        {
            {FireBallDirection.left, new Vector2(-300, 50)},
            {FireBallDirection.right, new Vector2(300, 50)}
        };
        private readonly float gravity = 600f;
        private readonly float weight = 20f;
        public bool Explosion { get; private set; }
        private float explosionTimer = 0.2f;
        private Vector2 explosionOffSet = new Vector2(-16, 0);
        public FireBall(Vector2 position, FireBallDirection direction)
        {
            Position = position;
            velocityDictionary.TryGetValue(direction, out Vector2 velocity);
            Physics = new Physics(velocity, gravity, weight);
            Physics.ApplyGravity();
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            Explosion = false;
            AudioFactory.Instance.CreateSound("fireball").Play();
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
            sprite.SetLayer(1f);
            Position += explosionOffSet;
            Explosion = true;
        }
        public override void Update(GameTime gameTime)
        {
            if (Explosion)
            {
                sprite.Update(gameTime);
                explosionTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (explosionTimer <= 0)
                    ObjState = ObjectState.Destroy;
            }
            else
                base.Update(gameTime);
        }
    }
}
