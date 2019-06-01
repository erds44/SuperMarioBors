using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using SuperMarioBros.Interfaces.States;
using SuperMarioBros.Classes.Objects.KoopaObject.KoopaState;

namespace SuperMarioBros.Classes.Objects.KoopaObject
{
    public class KoopaObject : IObject
    {
        private IGoombaState state;
        private Vector2 location;
        private ISprite Sprite; 
        public KoopaObject(Vector2 location)
        {
            state = new LeftMovingKoopaState(this);
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
        public void Draw(SpriteBatch SpriteBatch)
        {
            Sprite.Draw(SpriteBatch, location);
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
            Sprite.Update();
        }

        public void ChangeSprite(ISprite Sprite)
        {
            this.Sprite = Sprite;
        }
        public bool CheckLeftEdge()
        {
            if (location.X <= 50)
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
