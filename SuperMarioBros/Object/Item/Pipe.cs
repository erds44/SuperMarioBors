using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Managers;
using SuperMarioBros.Objects;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Items
{
    public class Pipe : IStatic
    {
        public ObjectState ObjState { get; set; }

        public Vector2 Position { get; set; }
        private readonly ISprite sprite;
        public Pipe(Vector2 location)
        {
            Position = location;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, Position);
        }

        public Rectangle HitBox()
        {
            Point size = SizeManager.ObjectSize(GetType());
            return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
        }

        public void Update()
        {
            sprite.Update();
        }

        public void Destroy()
        {
            
        }
    }
}
