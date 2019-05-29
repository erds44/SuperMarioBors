using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Class.Object.MarioObject.MarioState;
using SuperMarioBros.Interface;
using SuperMarioBros.Interface.State;

namespace SuperMarioBros.Class.Object.MarioObject
{
    public class MarioObject : IObject
    {
        private IMarioState state;
        private ISprite sprite;
        public Vector2 location;
        public int jumpTimer;
        public MarioObject(Vector2 location, string type)
        {
            state = new RightIdleMarioState(this, type);
            //this.game = game;
            this.location = location;
            jumpTimer = 6;
        }

        public void Left()
        {
            state.Left();
        }

        public void Down()
        {
            state.Down();
        }

        public void Up()
        {
            state.Up();
        }

        public void Right()
        {
            state.Right();
        }

        public void ToSmall()
        {
            state.ToSmall();
        }

        public void ToBig()
        {
            state.ToBig();
        }

        public void ToFire()
        {
            state.ToFire();
        }

        public void Die()
        {
            state.Die();
        }

        public void Move(Vector2 motion)
        {
            if(location.X + motion.X < 780 && location.X + motion.X > 0)
            {
                location.X += motion.X;
            }
            if(location.Y + motion.Y < 580 && location.Y + motion.Y > 0)
            {
                location.Y += motion.Y;
            }
        }
        public void Jump(Vector2 motion)
        {
            if(jumpTimer > 3)
            {
                location += motion;
                jumpTimer--;
            }else if(jumpTimer > 0)
            {
                location -= motion;
                jumpTimer--;
            }
            else
            {
                jumpTimer = 6;
            }
        }
        public void Update()
        {
            state.Update();
            sprite.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
           // Vector2 size = sprite.Size();
            sprite.Draw(spriteBatch, new Vector2(location.X, location.Y));
            /* Could be sprite.Draw(spriteBatch, location); 
             * the sprite knows the size it needs to draw.
             * size is a vector2 attribute of Sprite class.
             * the sprite.Draw function could be 
             * public void Draw(SpriteBatch spriteBatch, Vector2 location)
             * {
             *  spriteBatch.Draw(texture, new Rectangle(location.x, location.y, size.x, size.y), white);
             * }
             * This is a scratch, I don't know if it works.
             */
        }
        public void ChangeSprite(ISprite sprite)
        {
            this.sprite = sprite;
        }
        public void ChangeState(IMarioState marioState)
        {
            this.state = marioState;
        }
    }
}
