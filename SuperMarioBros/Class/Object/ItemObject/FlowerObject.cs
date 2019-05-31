using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interface;

namespace SuperMarioBros.Class.Object.ItemObject
{
    public class FlowerObject :IObject
   {
        private Vector2 location;
        public ISprite FlowerSprite { get; set; }
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
