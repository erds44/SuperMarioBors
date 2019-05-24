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
    public class CoinObject : IObject
    {
        private Vector2 location;
        public ISprite coinSprite { get; set; }
        private int updateDelay;
        public CoinObject(Vector2 location)
        {
            this.location = location;
            coinSprite = SpriteFactory.CreateSprite("Coin");
        }
        public void Update()
        {
            updateDelay++;
            if (updateDelay == 5)
            {
                coinSprite.Update();
                updateDelay = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            coinSprite.Draw(spriteBatch, location);
        }
        public void UpdateSprite(ISprite sprite)
        {
            coinSprite = sprite;
        }
    }
}

