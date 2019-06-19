using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Items
{
    public class RedMushroom : IItem
    {
        public bool IsInvalid { get; set; }

        private readonly ISprite sprite;
        public Vector2 Position { get; set; }
        private ItemPhysics physics;
        private float changeSpeedFlag;
        private Vector2 offset = new Vector2(5, 0);
       // private Vector2 velocity;
        public RedMushroom(Vector2 location)
        {
            Position = location + offset;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            physics = new ItemPhysics(this, new Vector2(0, -40));
            changeSpeedFlag = location.Y - 40;
        }

        public void Draw(SpriteBatch SpriteBatch)
        {
            sprite.Draw(SpriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update();
            Position += physics.Displacement(gameTime);
            if (Position.Y <= changeSpeedFlag)
            {
                physics.SetSpeed(new Vector2(40, 0));
                ObjectsManager.Instance.Add(this);
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
