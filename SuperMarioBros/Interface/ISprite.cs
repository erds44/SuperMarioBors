using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioBros
{
    interface ISprite
    {
        void Update(ref Vector2 location);
        void Draw(SpriteBatch spriteBatc);
    }
}
