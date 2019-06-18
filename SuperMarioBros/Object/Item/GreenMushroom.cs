using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Items;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Items
{
    public class GreenMushroom : IItem
    {
        public bool IsInvalid { get; set; }

        private readonly ISprite sprite;
        public Vector2 Position { get; set; }
        public GreenMushroom(Vector2 location)
        {           
            Position = location;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
        }

        public void Draw(SpriteBatch SpriteBatch)
        {
            sprite.Draw(SpriteBatch, Position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update();
        }

        public Rectangle HitBox()
        {
            Point size = ObjectSizeManager.ObjectSize(GetType());
            return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
        }

        public void MoveUp()
        {
            throw new System.NotImplementedException();
        }

        public void MoveDown()
        {
            throw new System.NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new System.NotImplementedException();
        }

        public void MoveRight()
        {
            throw new System.NotImplementedException();
        }
    }
}
