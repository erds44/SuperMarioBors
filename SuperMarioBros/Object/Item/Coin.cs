using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Items
{
    public class Coin : AbstractItem, IItem

    {

        public Coin(Vector2 location)
        {
            Position = location;
            sprite = SpriteFactory.CreateSprite(GetType().Name);
        }

        public void MoveDown()
        {
            throw new System.NotImplementedException();
        }

        public void MoveLeft()
        {
            throw new System.NotImplementedException();
        }

        public void MoveRight()
        {
            throw new System.NotImplementedException();
        }

        public void MoveUp()
        {
            throw new System.NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update();
        }
    }
}

