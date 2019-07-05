using Microsoft.Xna.Framework;

namespace SuperMarioBros.Object.Pipes
{
    public class Pipe : AbstractPipe
    {
        /* includes SmallPipe, MiddlePipe, LargePipe, HighPipe
         * TeleportVertialSmallPipe, TeleportHorizontalSmallPipe, TeleportVertialLargePipe
         */
        public bool IsTeleporting { get; set; }
        public Pipe(Vector2 location, string pipeType)
        {
            Position = location;
            this.pipeType = pipeType;
            IsTeleporting = false;
            base.Initialize();
        }
        public void SetTeleporting()
        {
            IsTeleporting = false;
        }
    }
}
