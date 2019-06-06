using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{
    public class DisappearBlock : AbstractBlock
    {
        public DisappearBlock(Point location, Block block)
        {
            this.block = block;
            this.location = location;
            this.sprite = SpriteFactory.CreateSprite("HiddenBlock");
        }
        public override Rectangle HitBox()
        {
            return new Rectangle();
        }

        public override void Used()
        {
            // Do nothing.
        }
    }
}
