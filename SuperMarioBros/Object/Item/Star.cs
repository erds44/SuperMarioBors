using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Items
{
    public class Star : IItem
    {
        public bool IsInvalid { get; set; }
        private StarPhysics physics;
        public Vector2 Position { get; set; }
        private readonly ISprite sprite;
        private bool addFlag;
        private float speedChangeFlag = 0;
        private Vector2 offset = new Vector2(5, 0);
        public Star(Vector2 location)
        {
            Position = location + offset;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
            sprite.SetLayer(0);
            physics = new StarPhysics(this, new Vector2(0, -180));
            addFlag = false;
            speedChangeFlag += location.Y - 50;
        }

        public Rectangle HitBox()
        {
            Point size = ObjectSizeManager.ObjectSize(GetType());
            return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update();
            Position += physics.Displacement(gameTime);
            if (Position.Y <= speedChangeFlag && !addFlag)
            {
                physics.SetSpeed(new Vector2(40,-40));
                sprite.SetLayer(1.0f);
                ObjectsManager.Instance.Add(this);
                ObjectsManager.Instance.RemoveFromNonCollidable(this);
                addFlag = true;
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

