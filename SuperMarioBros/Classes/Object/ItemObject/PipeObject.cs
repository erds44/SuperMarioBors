using Microsoft.Xna.Framework;
using SuperMarioBros.Classes.Object.ItemObject;
using SuperMarioBros.Interfaces.Object;

namespace SuperMarioBros.Classes.Objects.ItemObject
{
    public class PipeObject : AbstractItem, IItem
    {
        public PipeObject(Vector2 location)
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
