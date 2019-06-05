using Microsoft.Xna.Framework;
using SuperMarioBros.Marios;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Items
{
    public class Pipe : AbstractItem, IItem
    {
        public Pipe(Vector2 location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("Pipe");
        }

        public void Collide(IMario mario)
        {
            mario.Obstacle();
        }
    }
}
