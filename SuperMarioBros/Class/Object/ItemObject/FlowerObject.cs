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
        private int updateDelay;
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
            updateDelay++;
            if(updateDelay == 15)
            {
                this.Update();
                updateDelay = 0;
            }
            flowerSprite.Draw(spriteBatch, location);
        }
        public void UpdateSprite(ISprite sprite)
        {
            flowerSprite = sprite;
        }
   }
}
