using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Items;
using SuperMarioBros.Managers;
using System;

namespace SuperMarioBros.Blocks
{
    public class ItemBrickBlock : AbstractBlock
    {
        private readonly Type itemType;
        private int itemCount;
        public ItemBrickBlock(Vector2 location, Type itemType = null, int itemCount = 1)
        {
            if (itemType is null) itemType = typeof(Coin);
            this.itemType = itemType;
            this.itemCount = itemCount;
            Position = location;
            State = new BrickBlockState(this);
            base.Initialize();
        }
        public override void Used()
        {
            if(itemCount > 0)
            {
                itemCount--;
                IItem item = (IItem)Activator.CreateInstance(itemType, Position);
                ObjectsManager.Instance.AddNonCollidable(item);
                if (itemCount == 0) State = new UsedBlockState(this);
            }
        }
    }
}
