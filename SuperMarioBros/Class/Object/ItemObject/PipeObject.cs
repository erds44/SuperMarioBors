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
        public ISprite pipeSprite { get; set; }
        public PipeObject(Vector2 location)
        {
            this.location = location;
            pipeSprite = SpriteFactory.CreateSprite("Pipe");
        }

       public void Update()
        {
            //Doing nothing
        }
       public void Draw(SpriteBatch spriteBatch)
        {
            pipeSprite.Draw(spriteBatch,location);
        }
        public void UpdateSprite(ISprite sprite)
        {
            pipeSprite = sprite;
        }

        public void ChangeSprite(ISprite sprite)
        {
           // Do Nothing
        }
    }
}
