using Microsoft.Xna.Framework;
using SuperMarioBros.Marios;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Items
{
    public class Flower :AbstractItem, IItem
   {
        public Flower(Vector2 location)
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
