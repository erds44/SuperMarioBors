using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interface;
using SuperMarioBros.Interface.Object.BlockObject;
using SuperMarioBros.Interface.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Class.Object.BlockObject
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
