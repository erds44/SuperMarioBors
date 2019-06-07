using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Backgrounds
{
    class SmallCloud : AbstractBackground
    {
        public SmallCloud(Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("SmallCloud");
        }
    }
}
