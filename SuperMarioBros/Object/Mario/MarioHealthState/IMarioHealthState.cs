using Microsoft.Xna.Framework;

namespace SuperMarioBros.Interfaces.State
{
    public interface IMarioHealthState 
    {
        void TakeDamage();
        void TakeRedMushroom();
        void TakeFireFlower();
        void Update(GameTime gameTime);
        void PowerPressed();
        void PowerReleased();
    }
}
