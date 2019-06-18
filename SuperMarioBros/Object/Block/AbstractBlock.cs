using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Blocks
{

    public abstract class AbstractBlock : IBlock
    {
        public bool IsInvalid { get; set; }

        public IBlockState State { get; protected set; }
        public ISprite Sprite { get; protected set; }
        public Vector2 Position { get; set; }

        public void ChangeState(IBlockState state)
        {
            this.State = state;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, Position);
        }

        public void Move()
        {
           // To Do
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
            return new Rectangle((int)Position.X, (int)Position.Y - size.Y, size.X, size.Y);
        }
    }
}
