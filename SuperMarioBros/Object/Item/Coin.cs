using Microsoft.Xna.Framework;
using SuperMarioBros.Managers;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using System;

namespace SuperMarioBros.Items
{
    public class Coin : AbstractItem, IItem
    {
        public event Action coinCollectEvent;
        private readonly float coinGravity = 100f;
        private float existingTimer = 2f;
        private Vector2 coinInitialVelocity = new Vector2(0, -100);
        public Coin(Vector2 location)
        {
            Position = location;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(0);
            Physics = new Physics(coinInitialVelocity, coinGravity, itemWeight);
            Physics.ApplyGravity(); 
            /* Since Initally item does not have gravity for responding state */
        }

        public override void Update(GameTime gameTime)
        {
            existingTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            sprite.Update(gameTime);
            Position += Physics.Displacement(gameTime);
            if (existingTimer <= 0)
                ObjState = ObjectState.Destroy;
        }
    }
}
