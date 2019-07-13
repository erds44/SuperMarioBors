using Microsoft.Xna.Framework;
using SuperMarioBros.Collisions;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Pipes
{
    public class TeleportPipe : AbstractPipe
    {
        /* Includes TeleportVertialSmallPipe, TeleportHorizontalSmallPipe, TeleportVertialLargePipe */
        public TeleportPipe(Vector2 location, Vector2 transferedLocation, string pipeType, Direction direction)
        {
            Position = location;
            this.PipeType = pipeType;
            base.Initialize();
            TransferedLocation = transferedLocation;
            TeleportDirection = direction;

        }
    }
}
