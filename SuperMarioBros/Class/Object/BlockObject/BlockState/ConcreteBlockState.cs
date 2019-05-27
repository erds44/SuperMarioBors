using SuperMarioBros.Interface.Object.BlockObject;
using SuperMarioBros.Interface.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Class.Object.BlockObject.BlockState
{
    public class ConcreteBlockState : IBlockState
    {
        private static string type = "concreteBlock";
        private IBlockObject block;

        public ConcreteBlockState(IBlockObject block)
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
