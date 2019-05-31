﻿using Microsoft.Xna.Framework;
using SuperMarioBros.Class.Object.BlockObject.BlockState;

namespace SuperMarioBros.Class.Object.BlockObject
{
    public class HiddenBlockObject : BlockObject
    {
        public HiddenBlockObject( Vector2 location)
        {
            this.location = location;
            this.state = new HiddenBlockState(this);
        }
    }
}
