using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;
using System;

namespace SuperMarioBros.Items
{
    public class RedMushroom : IItem
    {
        public bool IsInvalid { get; set; }

        private readonly ISprite sprite;
        public Vector2 Position { get; set; }
        private ItemPhysics physics;
        private bool addFlag;
        private Vector2 offset = new Vector2(5, 0);
        private float speedChangeFlag = 0;
       // private Vector2 velocity;
        public RedMushroom(Vector2 location)
        {
            Position = location + offset;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(0);
            physics = new ItemPhysics(this, new Vector2(0, -180));
            addFlag = false;
            speedChangeFlag += location.Y - 50;
        }

        public void Draw(SpriteBatch SpriteBatch)
        {
            sprite.Draw(SpriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update();
            Position += physics.Displacement(gameTime);
            if(Position.Y <= speedChangeFlag && !addFlag)
            {
                physics.SetSpeed(new Vector2(40, 0));
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

        public void ReverseDirection()
        {
            physics.MoveLeft();
        }

        public void MoveLeft()
        {
            physics.MoveRight();
        }

        public void Destroy()
        {
            //Do nothing.
        }

        public void ChangeDirection()
        {
            physics.ChangeDirection();
        }

        public void BumpUp()
        {
            physics.BumpUp();
        }
    }
}
