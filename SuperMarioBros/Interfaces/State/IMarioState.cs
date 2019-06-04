using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBros.Interfaces.State
{
    public interface IMarioState 
    {
        /* powerup always follows small-big-fire
           void PowerUp();
           For Sprint3, we assume RedMushroom and FireFlower can appear at the same time;
        */
        void TakeDamage();
        void RedMushroom();
        void FireFlower();
        void GreenMushroom();
    }
}
