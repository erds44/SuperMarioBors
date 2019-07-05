using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks;

namespace SuperMarioBros.Items
{
    public class Pipes : AbstractBlock
    {
        public bool IsTeleporting { get; set; }
        public Pipes(Vector2 location)
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
