using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using SuperMarioBros.Interfaces.Object;

namespace SuperMarioBros.Classes.Objects.MushroomObject
{
    public class RedMushroom : IItem
    {
        
        private Vector2 location;
        private readonly ISprite sprite;
        private int velocity;
        private readonly int leftEdge;
        private readonly int rightEdge;
        public RedMushroom(Vector2 location, int leftEdge, int rightEdge)
        {
            
            this.location = location;
            this.leftEdge = leftEdge;
            this.rightEdge = rightEdge;
            velocity = 1;
            sprite = SpriteFactory.CreateSprite("RedMushroom");        
        }

        public void Draw(SpriteBatch SpriteBatch)
        {
            sprite.Draw(SpriteBatch, location);
        }

        public void Update()
        {
            this.Move();
            sprite.Update();
        }

        public void Move()
        {
            this.location.X += this.velocity;
            this.CheckEdge();
        }

        private void CheckEdge()
        {
            if (location.X < leftEdge)
            {
                location.X = 2 * leftEdge - location.X;
                velocity *= -1;
            }
            else if(location.X > rightEdge)
            {
                location.X = 2 * rightEdge - location.X;
                velocity *= -1;
            }
        }


        public Rectangle HitBox()
        {
            return new Rectangle((int)location.X, (int)(location.Y - sprite.Height()), sprite.Width(), sprite.Height());
        }
        public void Collide(IMario mario)
        {
            mario.RedMushroom();
        }

    }
}
