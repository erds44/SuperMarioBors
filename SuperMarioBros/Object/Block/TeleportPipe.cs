using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks;
using SuperMarioBros.Collisions;

namespace SuperMarioBros.Items
{
    public class TeleportPipes : AbstractBlock
    {
        public Vector2 TransferedLocation { get; private set; }
        public Direction TeleportDirection { get; private set; }
        public bool Teleported { get; set; }
        public TeleportPipes(Vector2 location, Vector2 transferedLocation, Direction direction)
        {
            Position = location;
            TransferedLocation = transferedLocation;
            TeleportDirection = direction;
            Teleported = false;
            base.Initialize();
            Sprite.SetLayer(1f);
        }
    }
}
