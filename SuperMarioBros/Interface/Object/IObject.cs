using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.Interface
{
    public interface IObject
    {
        /* Guys, in future we still need to draw all objects, 
         * report their location, hitbox, etc. 
         * Therefore, it is still necessary to create this interface.*/
        void Draw(SpriteBatch spriteBatch);
        void Update();
        void ChangeSprite(ISprite sprite);
        
        //void ReportHitBox();
    }
}
