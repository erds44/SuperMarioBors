﻿using SuperMarioBros.Interface.Object.BlockObject;
using SuperMarioBros.Interface.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Class.Object.BlockObject.BlockState
{
    public class BrickBlockState : IBlockState
    {
        private static string type = "brickBlock";
        private IBlockObject block;
        private BrickBlockObject brickBlockObject;

        public BrickBlockState(IBlockObject block)
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
            block.ChangeState(new DisappearBlockState(block));
        }

        public void ToUsed()
        {
            //Do nothing.
        }
    }
}
