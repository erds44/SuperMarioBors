using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Sprites;
using System;

namespace SuperMarioBros.Blocks
{
    public abstract class AbstractBlock : IBlock
    {
        protected Block block;
        protected Point location;
        protected ISprite sprite;

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }
        public void SetRef(Block block)
        {
            this.block = block;
        }

        public void Move(Point motion)
        {
            this.location += motion;
        }

        public void Update()
        {
            this.sprite.Update();
        }

        public void ChangeSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }
        public abstract void Used();

        public abstract Rectangle HitBox();

        public Type GetRealType()
        {
            return this.block.GetType();
        }
    }
}
