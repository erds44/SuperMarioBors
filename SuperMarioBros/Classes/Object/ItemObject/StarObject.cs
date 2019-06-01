using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Classes.Objects.ItemObject
{
    public class StarObject : IObject
    {
        private Vector2 location;
        private ISprite StarSprite;
        public StarObject(Vector2 location)
        {
            this.location = location;
            StarSprite = SpriteFactory.CreateSprite("Star");
        }

        public void Update()
        {
            StarSprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            StarSprite.Draw(spriteBatch, location);
        }
        public void UpdateSprite(ISprite sprite)
        {
            StarSprite = sprite;
        }

        public void ChangeSprite(ISprite sprite)
        {
            // Do Nothing
        }
    }
}

