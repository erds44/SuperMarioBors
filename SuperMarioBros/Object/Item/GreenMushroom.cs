using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;
using System;

namespace SuperMarioBros.Items
{
    public class GreenMushroom : IItem
    {
        public bool IsInvalid { get; set; }

        private readonly ISprite sprite;
        public Vector2 Position { get; set; }
        private ItemPhysics physics;
        private bool addFlag;
        private Vector2 offset = new Vector2(5, 0);
        private float timer;
        public GreenMushroom(Vector2 location)
        {
            Position = location + offset;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(0);
            physics = new ItemPhysics(this, new Vector2(0, -40));
            addFlag = false;
            timer = 0;
        }

        public void Draw(SpriteBatch SpriteBatch)
        {
            sprite.Draw(SpriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            sprite.Update();
            Position += physics.Displacement(gameTime);
            if (Math.Floor(timer) == 1 && !addFlag)
            {
                physics.SetSpeed(new Vector2(60, 0));
                sprite.SetLayer(1.0f);
                ObjectsManager.Instance.Add(this);
                ObjectsManager.Instance.RemoveFromNonCollidable(this);
                addFlag = true;
            }

        }


        public Rectangle HitBox()
        {
            Point size = ObjectSizeManager.ObjectSize(GetType());
            return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
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

    }
}
