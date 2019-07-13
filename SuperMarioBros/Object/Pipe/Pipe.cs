using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Pipes
{
    public class Pipe : AbstractPipe
    {
        /* includes SmallPipe, MiddlePipe, LargePipe, HighPipe
         * TeleportVertialSmallPipe, TeleportHorizontalSmallPipe, TeleportVertialLargePipe
         */
        public Pipe(Vector2 location,string pipeType)
        {
            Position = location;
            this.PipeType = pipeType;
            base.Initialize();
        }
        public void SetTeleporting()
        {
            Teleported = false;
        }
    }
}
