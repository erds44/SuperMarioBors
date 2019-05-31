﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interface;

namespace SuperMarioBros.Class.Object.ItemObject
{
    public class PipeObject : IObject
    {
        private Vector2 location;
        public ISprite PipeSprite { get; set; }
        public PipeObject(Vector2 location)
        {
            this.location = location;
            PipeSprite = SpriteFactory.CreateSprite("Pipe");
        }

       public void Update()
        {
            //Doing nothing
        }
       public void Draw(SpriteBatch spriteBatch)
        {
            PipeSprite.Draw(spriteBatch,location);
        }
        public void UpdateSprite(ISprite sprite)
        {
            PipeSprite = sprite;
        }

        public void ChangeSprite(ISprite sprite)
        {
           // Do Nothing
        }
    }
}
