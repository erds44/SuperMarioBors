using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interface;

namespace SuperMarioBros.Class.Object.ItemObject
{
    public class CoinObject : IObject
    {
        private Vector2 location;
        public ISprite CoinSprite { get; set; }
        public CoinObject(Vector2 location)
        {
            this.location = location;
            CoinSprite = SpriteFactory.CreateSprite("Coin");
        }
        public void Update()
        {
                CoinSprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            CoinSprite.Draw(spriteBatch, location);
        }
        public void UpdateSprite(ISprite sprite)
        {
            CoinSprite = sprite;
        }

        public void ChangeSprite(ISprite sprite)
        {
            // Do Nothing
        }
    }
}

