using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks
{
    public class BrickBlock : AbstractBlock 
    {
        public BrickBlock(Vector2 location)
        {
            Position = location;
            this.State = new BrickBlockState(this);
            base.Initialize();
        }
        
        public override void Used()
        {
            IsInvalid = true;
            base.Used();
        }

    }
}
