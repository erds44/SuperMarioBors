using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;
using System;

namespace SuperMarioBros.Items
{
    public class Coin : AbstractItem, IItem
    {
        private ItemPhysics physics;
        private Vector2 offset = new Vector2(15, -50);
        private float timer;
        public Coin(Vector2 location)
        {
            Position = location + offset;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            physics = new ItemPhysics(this, new Vector2(0, -150));
            timer = 0;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            sprite.Update();
            Position += physics.Displacement(gameTime);
            if (timer >= 0.3 )
            {
                ObjectsManager.Instance.RemoveFromNonCollidable(this);
            }

        }

        public void MoveUp()
        {
            physics.MoveUp();
        }

        public void MoveDown()
        {
            physics.MoveDown();
        }

        public void MoveLeft()
        {
            physics.MoveLeft();
        }

        public void MoveRight()
        {
            physics.MoveRight();
        }

        public void Destroy()
        {
            //Do nothing.
        }

        public void ChangeDirection()
        {
            //Do Nothing
        }

        public void BumpUp()
        {
            // Do Nothing
        }
    }
}
