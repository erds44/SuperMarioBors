using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using SuperMarioBros.Interfaces.Objects.BlockObjects;
using SuperMarioBros.Interfaces.States;

namespace SuperMarioBros.Classes.Objects.BlockObjects
{
    public abstract class BlockObject : IBlockObject
    {
        protected IBlockState state;
        protected Vector2 location;
        protected ISprite sprite;
        //protected MarioGame game;

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
            this.state.Update();
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
    }
}
