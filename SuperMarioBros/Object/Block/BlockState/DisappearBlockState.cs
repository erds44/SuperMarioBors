using SuperMarioBros.Commands;
using SuperMarioBros.SpriteFactories;
using System;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class DisappearBlockState : IBlockState
    {
       // private readonly IBlockObject block;
        public DisappearBlockState(IBlock block)
        {
            //this.block = block;
            block.ChangeState(new HiddenBlockState(block));
        }

        public void ToUsed()
        {
            //Do nothing.
        }
    }
}
