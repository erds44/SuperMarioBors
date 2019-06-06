using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Items
{
    public class RedMushroom : IItem
    {
        
        private Point location;
        private readonly ISprite sprite;
        public RedMushroom(Point location)
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
    }
}
