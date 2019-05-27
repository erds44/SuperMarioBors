using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Class.Object.ItemObject
{
   public class FlowerObject :IObject
   {
        private Vector2 location;
        public ISprite flowerSprite { get; set; }
        public FlowerObject(Vector2 location)
        {
            this.location = location;
            flowerSprite = SpriteFactory.CreateSprite("Flower");
        }
        public void Update()
        {
            flowerSprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            flowerSprite.Draw(spriteBatch, location);
        }
        public void UpdateSprite(ISprite sprite)
        {
            flowerSprite = sprite;
        }

        public void ChangeSprite(ISprite sprite)
        {
           //Do Nothing
        }
    }
}
