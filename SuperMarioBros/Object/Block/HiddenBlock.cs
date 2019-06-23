using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Items;
using SuperMarioBros.Managers;
using SuperMarioBros.SpriteFactories;
using System;

namespace SuperMarioBros.Blocks
{
    public class HiddenBlock : AbstractBlock
    {
        public readonly Type ItemType;
        private int itemCount;
        public HiddenBlock(Vector2 location, Type itemType = null, int itemCount = 1)
        {
            this.itemCount = itemCount;
            this.ItemType = itemType;
            Position = location;
            State = new HiddenBlockState(this);
            Initialize();
        }
        public override void Used()
        {
            if(itemCount > 0)
            {
                itemCount--;
                if (itemCount == 0) State.ToUsed();
            }
        }
    }
}
