using Microsoft.Xna.Framework;

namespace SuperMarioBros.Interfaces.State
{
    public interface IMarioHealthState 
    {
        void TakeDamage();
        void TakeRedMushroom();
        void OnFireFlower();
        void Update(GameTime gameTime);
    }
}
