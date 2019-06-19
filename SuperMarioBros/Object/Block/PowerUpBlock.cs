using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Items;
using SuperMarioBros.Objects;
using System;

namespace SuperMarioBros.Blocks
{
    public class PowerUpBlock : AbstractBlock
    {
        public bool IsFlower { get; set; }
        private int itemCount;
        public PowerUpBlock(Vector2 location, int itemCount = 1)
        {
            IsFlower = false;
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
                IItem item = (IItem)Activator.CreateInstance((IsFlower? typeof(Flower): typeof(RedMushroom)), Position);
                ObjectsManager.Instance.AddNonCollidable(item);
                if (itemCount == 0) State.ToUsed();
            }
        }
    }
}
