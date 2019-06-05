using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Items
{
    public class RedMushroom : IItem
    {
        
        private Vector2 location;
        private readonly ISprite sprite;
        public RedMushroom(Vector2 location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("RedMushroom");        
        }

        public void Draw(SpriteBatch SpriteBatch)
        {
            sprite.Draw(SpriteBatch, location);
        }

        public void Update()
        {
            sprite.Update();
        }


        public Rectangle HitBox()
        {
            return new Rectangle((int)location.X, (int)(location.Y - sprite.Height()), sprite.Width(), sprite.Height());
        }

        public void Collide(IMario mario)
        {
            mario.RedMushroom();
        }
    }
}
