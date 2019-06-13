using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Blocks
{

    public abstract class AbstractBlock : IBlock
    {
        public IBlockState State { get; protected set; }
        public Point Location { get; protected set; }
        public ISprite Sprite { get; protected set; }

        public void ChangeState(IBlockState state)
        {
            this.State = state;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Location);
        }

        public void Move(Point motion)
        {
            this.Location += motion;
        }

        public void Update()
        {
            this.Sprite.Update();
        }

        public void ChangeSprite(ISprite sprite)
        {
            this.Sprite = sprite;
        }
        public void Used()
        {
            this.State.ToUsed();
        }

        public Rectangle HitBox()
        {
            Point size = ObjectSizeManager.ObjectSize(GetType());
            return new Rectangle(Location.X, Location.Y - size.Y, size.X, size.Y);
        }
    }
}
