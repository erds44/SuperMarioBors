using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Blocks
{
    public class BlueBrickBlock: BrickBlock
    {
        public BlueBrickBlock(Vector2 location) : base(location)
        {

        }

        public override void Bumped()
        {
            base.Bumped();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Used()
        {
            base.Used();
        }
        public override void Borken()
        {
            base.Borken();
        }

    }
}
