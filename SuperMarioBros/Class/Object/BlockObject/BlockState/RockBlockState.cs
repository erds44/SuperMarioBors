using SuperMarioBros.Interface.Object.BlockObject;
using SuperMarioBros.Interface.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Class.Object.BlockObject.BlockState
{
    public class RockBlockState : IBlockState
    {
        private static string type = "rockBlock";
        private IBlockObject block;

        public RockBlockState(IBlockObject block)
        {
            this.block = block;
            block.ChangeSprite(SpriteFactory.CreateSprite(type));
        }

        public string Type()
        {
            return type;
        }

        public void Update()
        {
            //Do nothing.
        }
        public void ToDisappear()
        {
            //Do nothing.
        }

        public void ToUsed()
        {
            //Do nothing.
        }
    }
}
