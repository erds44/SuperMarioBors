using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Classes.Object.ItemObject;
using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Classes.Objects.ItemObject
{
    public class PipeObject : AbstractItem, IObject
    {
        public PipeObject(Vector2 location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("Pipe");
        }
    }
}
