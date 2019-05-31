using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interface;

namespace SuperMarioBros.Class.Object.ItemObject
{
    public class StarObject : IObject
    {
        private Vector2 location;
        public ISprite StarSprite { get; set; }
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

