using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Interface
{
    public interface IObject
    {
        /* Guys, in future we still need to draw all objects, 
         * report their location, hitbox, etc. 
         * Therefore, it is still necessary to create this interface.*/
        void Draw(SpriteBatch spriteBatch);
        void Update();
        void UpdateSprite(ISprite sprite);
        
        //void ReportHitBox();
    }
}
