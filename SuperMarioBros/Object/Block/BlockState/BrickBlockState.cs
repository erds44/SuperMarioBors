﻿using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class BrickBlockState : IBlockState
    {
        private readonly string type = "BrickBlock";
        private readonly IBlock block;

        public BrickBlockState(IBlock block)
        {
            this.block = block;
            block.ChangeSprite(SpriteFactory.CreateSprite(type));
        }

        public void ToUsed()
        {
            block.ChangeState(new DisappearBlockState(block));
        }
    }
}
