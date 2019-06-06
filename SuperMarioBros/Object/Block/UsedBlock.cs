using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{
    public class UsedBlock : AbstractBlock
    {
        public UsedBlock(Point location)
        {
            this.location = location;
            this.sprite = SpriteFactory.CreateSprite(this.GetType().Name);
        }

        public override Rectangle HitBox()
        {
            return new Rectangle(location.X, location.Y - sprite.Height(), sprite.Width(), sprite.Height());
        }
        public override void Used()
        {
            //Do nothing.
        }
    }
}
