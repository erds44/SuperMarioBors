using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces;
using SuperMarioBros.Interfaces.Objects;
using System;

namespace SuperMarioBros.Classes.Objects.MushroomObject
{
    public class MushroomObject : IMushroomObject
    {
        
        private Vector2 location;
        private ISprite Sprite;
        private int velocity;
        private readonly int leftEdge;
        private readonly int rightEdge;
        public MushroomObject(Vector2 location, int leftEdge, int rightEdge, String type)
        {
            
            this.location = location;
            this.leftEdge = leftEdge;
            this.rightEdge = rightEdge;
            if (type == "Green")
            {
                velocity = 10;
                Sprite = SpriteFactory.CreateSprite("GreenMushroom");
            }
            else
            {
                velocity = 5;
                Sprite = SpriteFactory.CreateSprite("RedMushroom");
            }
        }

        public void Draw(SpriteBatch SpriteBatch)
        {
            Sprite.Draw(SpriteBatch, location);
        }

        public void Update()
        {
            this.Move();
            Sprite.Update();
        }

        public void UpdateSprite(ISprite Sprite)
        {
            this.Sprite = Sprite;
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

        public void BeKicked()
        {
            // Do Nothing
        }

        public void ChangeSprite(ISprite Sprite)
        {
            // Do Nothing
        }
    }
}
