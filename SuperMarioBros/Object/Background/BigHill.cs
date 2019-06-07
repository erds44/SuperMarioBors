using Microsoft.Xna.Framework;
using SuperMarioBros.Backgrounds;
using SuperMarioBros.SpriteFactories;
using SuperMarioBros.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Backgrounds
{
    public class BigHill : AbstractBackground
    {
        public BigHill(Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite("BigHill");
        }



    }
}
