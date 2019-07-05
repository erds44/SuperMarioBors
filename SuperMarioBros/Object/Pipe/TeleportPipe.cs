using Microsoft.Xna.Framework;
using SuperMarioBros.Collisions;

namespace SuperMarioBros.Object.Pipes
{
    public class TeleportPipe : AbstractPipe
    {
        /* Includes TeleportVertialSmallPipe, TeleportHorizontalSmallPipe, TeleportVertialLargePipe */
        public TeleportPipe(Vector2 location, Vector2 transferedLocation, string pipeType, Direction direction)
        {
            Position = location;
            this.pipeType = pipeType;
            base.Initialize();
            TransferedLocation = transferedLocation;
            TeleportDirection = direction;

        }
    }
}
