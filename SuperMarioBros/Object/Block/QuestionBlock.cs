using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Items;
using SuperMarioBros.Objects;
using System;

namespace SuperMarioBros.Blocks
{
    public class QuestionBlock : AbstractBlock
    {
        private Type itemType;
        private int itemCount;
        public QuestionBlock(Vector2 location, Type itemType = null, int itemCount = 1)
        {
            if (itemType is null) itemType = typeof(Coin);
            this.itemType = itemType;
            this.itemCount = itemCount;
            Position = location;
            State = new QuestionBlockState(this);
            base.Initialize();
        }
        public override void Used()
        {
            if(itemCount > 0)
            {
                itemCount--;
                IItem item = (IItem)Activator.CreateInstance(itemType, Position);
                ObjectsManager.Instance.AddNonCollidable(item);
                if (itemCount == 0) State.ToUsed();
            }
        }
    }
}
