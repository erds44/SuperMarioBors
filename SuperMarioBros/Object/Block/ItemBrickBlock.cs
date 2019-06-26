using Microsoft.Xna.Framework;
using System;

namespace SuperMarioBros.Blocks
{
    public class ItemBrickBlock : AbstractBlock
    {
        private int itemCount;
        public ItemBrickBlock(Vector2 location, Type itemType, int itemCount)
        {
            this.ItemType = itemType;
            this.itemCount = itemCount;
            Position = location;
            base.Initialize();
        }

        public override void Bumped()
        {
            base.Bumped();
            itemCount--;
            if (itemCount <= 0) ObjState = ObjectState.Destroy;
        }
    }
}
