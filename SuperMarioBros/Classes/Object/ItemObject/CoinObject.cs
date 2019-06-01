using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Classes.Objects.ItemObject
{
    public class CoinObject : IObject
    {
        private Vector2 location;
        private ISprite CoinSprite;
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

