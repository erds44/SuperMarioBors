using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks;

namespace SuperMarioBros.Items
{
    public class Pipe : AbstractBlock
    {
        public bool IsTeleporting { get; set; }
        public Pipe(Vector2 location)
        {
            Position = location;
            IsTeleporting = false;
            base.Initialize();
            Sprite.SetLayer(1f);
        }
        public void SetTeleporting()
        {
            IsTeleporting = false;
        }
    }
}
