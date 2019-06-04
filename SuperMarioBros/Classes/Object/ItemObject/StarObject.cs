using Microsoft.Xna.Framework;
using SuperMarioBros.Classes.Object;
using SuperMarioBros.Classes.Object.ItemObject;
using SuperMarioBros.Classes.Object.MarioObject;
using SuperMarioBros.Interfaces.Object;

namespace SuperMarioBros.Classes.Objects.ItemObject
{
    public class StarObject : AbstractItem, IStar
    {
        public StarObject(Vector2 location)
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

