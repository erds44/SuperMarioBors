using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Class.Object.MushroomObject.MushroomState;
using SuperMarioBros.Interface;
using SuperMarioBros.Interface.Object;
using SuperMarioBros.Interface.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Class.Object.MushroomObject
{
    public class MushroomObject : IMushroomObject
    {
        
        public Vector2 location;
        private Vector2 initialLocation;
        public ISprite sprite { get; set; }
        public int velocity;
        public int leftEdge;
        public int rightEdge;
        private IMushroomState mushroomState;
        public MushroomObject(Vector2 location, int leftEdge, int rightEdge, String type)
        {
            
            this.location = location;
            this.initialLocation = location;
            this.leftEdge = leftEdge;
            this.rightEdge = rightEdge;
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
            mushroomState = new LeftMovingMushroomState(this);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, location);
        }

        public void Update()
        {
            this.Move();
            sprite.Update();
        }

        public void UpdateSprite(ISprite sprite)
        {
            this.sprite = sprite;
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
                mushroomState = new RightMovingMushroomState(this);
            }
            else if(location.X > rightEdge)
            {
                location.X = 2 * rightEdge - location.X;
                velocity *= -1;
                mushroomState = new LeftMovingMushroomState(this);
            }
        }
        public void Reset()
        {
            mushroomState = new LeftMovingMushroomState(this);
            location = initialLocation;
        }

        public void BeKicked()
        {
            mushroomState.BeKicked();
        }

    }
}
