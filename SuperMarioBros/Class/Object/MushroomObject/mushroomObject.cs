using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interface;
using SuperMarioBros.Interface.Object;
using System;

namespace SuperMarioBros.Class.Object.MushroomObject
{
    public class MushroomObject : IMushroomObject
    {
        
        public Vector2 location;
        public ISprite Sprite { get; set; }
        public int velocity;
        public int leftEdge;
        public int rightEdge;
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

        }

        public void ChangeSprite(ISprite Sprite)
        {
            // Do Nothing
        }
    }
}
