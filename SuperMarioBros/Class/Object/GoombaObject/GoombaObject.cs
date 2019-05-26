using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interface;
using SuperMarioBros.Interface.State;
using SuperMarioBros.Class.Object.GoombaObject.GoombaState;
namespace SuperMarioBros.Class.Object.GoombaObject
{
    public class GoombaObject : IObject
    {
        private IGoombaState state;
        private Vector2 location;
        public ISprite sprite { get; set; }
        public GoombaObject( Vector2 location)
        {
            state = new LeftMovingGoombaState(this);
            this.location = location;
        }
        //public void ChangeDirection()
        //{
        //    state.ChangeDirection();
        //}

        public void BeStomped()
        {
            state.BeStomped();
        }

        public void BeFlipped()
        {
            state.BeFlipped();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }
        public void Move(Vector2 motion)  // This includes left and right
        {
            if (location.X + motion.X < 780 && location.X + motion.X > 0)
            {
                location.X += motion.X;
            }
            if (location.Y + motion.Y < 580 && location.Y + motion.Y > 0)
            {
                location.Y += motion.Y;
            }
        }

        public void Update()
        {
            state.Update();
            sprite.Update();
        }

        public void UpdateSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }
        public bool CheckLeftEdge()
        {
            if(location.X <= 50)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckRightEdge()
        {
            if (location.X >= 200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void ChangeState(IGoombaState state)
        {
            this.state = state;
        }
    }
}
