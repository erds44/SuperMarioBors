﻿using SuperMarioBros.Interface.Object.BlockObject;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.BlockObject.BlockState
{
    public class DisappearBlockState : IBlockState
    {
        private readonly static string type = "DisappearBlock";
       // private readonly IBlockObject block;
        public DisappearBlockState(IBlockObject block)
        {
            //this.block = block;
            block.ChangeSprite(SpriteFactory.CreateSprite("HiddenBlock"));
        }

        public void ToDisappear()
        {
            //Do nothing.
        }

        public void ToUsed()
        {
            //Do nothing.
        }

        public string Type()
        {
            return type;
        }

        public void Update()
        {
            //Do nothing.
        }
    }
}
