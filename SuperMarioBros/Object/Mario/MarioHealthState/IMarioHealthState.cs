using Microsoft.Xna.Framework;

namespace SuperMarioBros.Interfaces.State
{
    public interface IMarioHealthState 
    {
        /* powerup always follows small-big-fire
           void PowerUp();
           For Sprint3, we assume RedMushroom and FireFlower can appear at the same time;
        */
        void TakeDamage();
        void RedMushroom();
        void OnFireFlower();
        void GreenMushroom();
        void Coin();
        // Coin might not be implemented in Mario Class
        // We put the mehtod here for now
        void Update(GameTime gameTime);
    }
}
