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
    public class StarObject : IObject
    {
        private Vector2 location;
        public ISprite starSprite { get; set; }
        public StarObject(Vector2 location)
        {
            this.location = location;
            starSprite = SpriteFactory.CreateSprite("Star");
        }

        public void Update()
        {
            starSprite.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            starSprite.Draw(spriteBatch, location);
        }
        public void UpdateSprite(ISprite sprite)
        {
            starSprite = sprite;
        }

        public void ChangeSprite(ISprite sprite)
        {
            // Do Nothing
        }
    }
}

