using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Class.Object.ItemObject
{
    public class PipeObject : IObject
    {
        private Vector2 location;
        private ISprite pipeSprite;

        public PipeObject(Vector2 location)
        {
            this.location = location;
            pipeSprite = SpriteFactory.CreateSprite("Pipe");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            pipeSprite.Draw(spriteBatch, location);
        }
        public void Update()
        {
            //Doing nothing
        }
        public void ChangeSprite(ISprite sprite)
        {
            //Doing nothing
        }
    }
}
