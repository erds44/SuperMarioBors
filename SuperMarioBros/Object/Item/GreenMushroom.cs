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
        
        private Point location;
        private readonly ISprite sprite;
        public GreenMushroom(Point location)
        {           
            this.location = location;
            sprite = SpriteFactory.CreateSprite("GreenMushroom");
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

    }
}
