using Microsoft.Xna.Framework;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Items
{
    public class Coin : AbstractItem, IItem
    {
        private float existingTimer = Timers.CoinTimeSpan;
        public Coin(Vector2 location)
        {
            Position = location;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(Layers.CoinLayer);
            Physics = new Physics(PhysicsConsts.CoinInitialVelocity, PhysicsConsts.CoinGravity, itemWeight);
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
