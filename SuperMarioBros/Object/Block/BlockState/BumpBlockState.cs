using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks.BlockStates
{
    //This is for collision handle use.
    public class BumpBlockState : IBlockState
    {
        private IBlock block;
        private IBlockState state;

        public BumpBlockState(IBlock block, IBlockState state)
        {
            this.block = block;
            this.state = state;
        }

        public void ToUsed()
        {
            //Do nothing.
        }

        public void Restore()
        {
            block.ChangeState(state);
        }
    }
}
