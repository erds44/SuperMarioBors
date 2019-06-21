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
        public Type ItemType { get; private set; }
        public bool IsFlower { get; set; }
        public HiddenBlock(Vector2 location, Type itemType = null, int itemCount = 1)
        {
            IsFlower = false;
            this.ItemType = itemType;
            Position = location;
            State = new HiddenBlockState(this);
            base.Initialize();
        }
        public override void Used()
        {
            IItem item;
            if (ItemType == null)
                item = (IItem)Activator.CreateInstance((IsFlower ? typeof(Flower) : typeof(RedMushroom)), Position);
            else
                item = (IItem)Activator.CreateInstance(ItemType, Position);
            ObjectsManager.Instance.AddNonCollidable(item);
            State = new UsedBlockState(this);

        }
    }
}
