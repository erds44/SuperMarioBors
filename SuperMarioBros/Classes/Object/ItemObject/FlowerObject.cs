using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Classes.Objects.ItemObject
{
    public class FlowerObject :IObject
   {
        private Vector2 location;
        private ISprite FlowerSprite;
        public FlowerObject(Vector2 location)
        {
            this.location = location;
            FlowerSprite = SpriteFactory.CreateSprite("Flower");
        }
        public void Update()
        {
            FlowerSprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            FlowerSprite.Draw(spriteBatch, location);
        }
        public void UpdateSprite(ISprite sprite)
        {
            FlowerSprite = sprite;
        }

        public void ChangeSprite(ISprite sprite)
        {
           //Do Nothing
        }
    }
}
