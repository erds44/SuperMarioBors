using Microsoft.Xna.Framework;
using SuperMarioBros.Marios;
using SuperMarioBros.Objects;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Items
{
    public class Star : AbstractItem, IStar
    {
        public Star(Vector2 location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("Star");
        }

        public void Collide(ObjectsManager objectsManager, IMario mario)
        {
            objectsManager.DecorateMario( new StarMario(mario, objectsManager));
        }
    }
}

