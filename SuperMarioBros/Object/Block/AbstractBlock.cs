using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Managers;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Blocks
{

    public abstract class AbstractBlock : IBlock
    {
        public ObjectState ObjState { get; set; }

        public IBlockState State { get; protected set; }
        public Vector2 Position { get; set; }
        public ISprite Sprite { get; protected set; }

        protected bool isBumping;
        protected int bumpingCount;
        protected Vector2 drawPosition;
        protected void Initialize()
        {
            ObjState = ObjectState.Normal;
            drawPosition = Position;
            isBumping = false;
            bumpingCount = 0;
        }
        public void ChangeState(IBlockState state)
        {
            this.State = state;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Sprite.Draw(spriteBatch, drawPosition);
        }

        public void Update()
        {
            if (isBumping)
            {
                if(bumpingCount == 20) {
                    isBumping = false;
                    if (State is BumpBlockState) ((BumpBlockState)State).Restore();
                    drawPosition = Position;
                    bumpingCount = 0;
                }
                else
                {
                    bumpingCount++;
                    if(bumpingCount < 10)
                    {
                        drawPosition.Y -= 3;
                    }
                    else
                    {
                        drawPosition.Y += 3;
                    }
                }
            }
            this.Sprite.Update();
        }

        public void ChangeSprite(ISprite sprite)
        {
            this.Sprite = sprite;
        }
        public virtual void Used()
        {
            this.State.ToUsed();
        }

        public Rectangle HitBox()
        {
            Point size = SizeManager.ObjectSize(GetType());
            return new Rectangle((int)drawPosition.X, (int)drawPosition.Y - size.Y, size.X, size.Y);
        }

        public void Bump()
        {
            State = new BumpBlockState(this, State);
            isBumping = true;
        }

        public void Destroy()
        {
            //Do nothing
        }
    }
}
