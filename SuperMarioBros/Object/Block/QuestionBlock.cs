using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Items;
using SuperMarioBros.Managers;
using System;

namespace SuperMarioBros.Blocks
{
    public class QuestionBlock : AbstractBlock
    {
        public readonly Type ItemType;
        private int itemCount;
        public QuestionBlock(Vector2 location, Type itemType = null, int itemCount = 1)
        {
            this.ItemType = itemType;
            this.itemCount = itemCount;
            Position = location;
            State = new QuestionBlockState(this);
            base.Initialize();
        }

        //public QuestionBlock(Vector2 location)
        //{
        //    itemType = typeof(Coin);
        //    this.itemType = itemType;
        //    this.itemCount = 1;
        //    Position = location;
        //    State = new QuestionBlockState(this);
        //    base.Initialize();
        //}
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
