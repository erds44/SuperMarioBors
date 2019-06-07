using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Backgrounds
{
    class SmallHill : AbstractBackground
    {
        public SmallHill(Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("SmallHill");
        }
    }
}
