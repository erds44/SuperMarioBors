using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Blocks
{
    public abstract class AbstractBlock : IBlock
    {
        protected IBlockState state;
        protected Vector2 location;
        protected ISprite sprite;

        public void ChangeState(IBlockState state)
        {
            this.state = state;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Move(Vector2 motion)
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
        public void Disappear()
        {
            this.state.ToDisappear();
        }
        public void Used()
        {
            this.state.ToUsed();
        }

        public Rectangle HitBox()
        {
            return new Rectangle((int)location.X, (int)(location.Y - sprite.Height()), sprite.Width(), sprite.Height());
        }
    }
}
