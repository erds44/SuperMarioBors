using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Blocks
{
    public abstract class AbstractBlock : IBlock
    {
        protected IBlockState state;
        protected Point location;
        protected ISprite sprite;

        public void ChangeState(IBlockState state)
        {
            this.state = state;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
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
        public void Used()
        {
            this.state.ToUsed();
        }

        public Rectangle HitBox()
        {
            if (this.state is DisappearBlockState) return new Rectangle();
            return new Rectangle(location.X, location.Y - sprite.Height(), sprite.Width(), sprite.Height());
        }
    }
}
