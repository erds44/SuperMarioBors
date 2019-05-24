using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Class.Object.BlockObject.BlockState;
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
    public class HiddenBlockObject : IBlockObject
    {
        private IBlockState state;
        private Vector2 location;
        private ISprite sprite;
        private MarioGame game; //For future use.

        public HiddenBlockObject(MarioGame game, Vector2 location)
        {
            this.game = game;
            this.location = location;
            this.state = new HiddenBlockState(this);
        }
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
    }
}
