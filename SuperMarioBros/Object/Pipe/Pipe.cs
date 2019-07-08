using Microsoft.Xna.Framework;

namespace SuperMarioBros.Object.Pipes
{
    public class Pipe : AbstractPipe
    {
        /* includes SmallPipe, MiddlePipe, LargePipe, HighPipe
         * TeleportVertialSmallPipe, TeleportHorizontalSmallPipe, TeleportVertialLargePipe
         */
        public Pipe(Vector2 location, string pipeType)
        {
            Position = location;
            this.pipeType = pipeType;
            base.Initialize();
        }
        public void SetTeleporting()
        {
            Teleported = false;
        }
    }
}
