using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using SuperMarioBros.Interfaces.Object;
using SuperMarioBros.Interfaces.Objects;
using System;

namespace SuperMarioBros.Classes.Objects.MushroomObject
{
    public class Mushroom : IMushroom
    {
        
        private Vector2 location;
        private ISprite sprite;
        private int velocity;
        private string type;
        private readonly int leftEdge;
        private readonly int rightEdge;
        public Mushroom(Vector2 location, int leftEdge, int rightEdge, string type)
        {
            
            this.location = location;
            this.leftEdge = leftEdge;
            this.rightEdge = rightEdge;
            this.type = type;
            if (type == "Green")
            {
                velocity = 10;
                sprite = SpriteFactory.CreateSprite("GreenMushroom");
            }
            else
            {
                velocity = 5;
                sprite = SpriteFactory.CreateSprite("RedMushroom");
            }
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

        public void UpdateSprite(ISprite Sprite)
        {
            this.sprite = Sprite;
        }
        public void Move()
        {
            //this.location.X += this.velocity;
            //this.CheckEdge();
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

        public void BeKicked()
        {
            // Do Nothing
        }

        public void ChangeSprite(ISprite Sprite)
        {
            // Do Nothing
        }

        public Rectangle HitBox()
        {
            return new Rectangle((int)location.X, (int)(location.Y - sprite.Height()), sprite.Width(), sprite.Height());
        }
        public void Collide(IMario mario)
        {
            if(type == "Red")
            {
                mario.RedMushroom();
            }
        }

    }
}
