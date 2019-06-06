using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.Blocks
{
    
    public class Block : IBlock
    {
        private AbstractBlock block;
        public Block(AbstractBlock block)
        {
            this.block = block;
            this.block.SetRef(this);
        }
        public Type GetRealType() // Intended to override.
        {   
            return this.block.GetType();
        }
        public void ChangeBlock(AbstractBlock block)
        {
            this.block = block;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.block.Draw(spriteBatch);
        }

        public Rectangle HitBox()
        {
            return this.block.HitBox();
        }

        public void Move(Point motion)
        {
            this.block.Move(motion);
        }

        public void Update()
        {
            this.block.Update();
        }

        public void Used()
        {
            this.block.Used();
        }
    }
}
