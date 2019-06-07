using Microsoft.Xna.Framework;
using SuperMarioBros.Backgrounds;
using SuperMarioBros.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Backgrounds
{
    class MiddleCloud : AbstractBackground
    {
        public MiddleCloud(Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("MiddleCloud");
        }
    }
}
