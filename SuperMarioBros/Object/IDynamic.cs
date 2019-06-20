using Microsoft.Xna.Framework;

namespace SuperMarioBros.Objects
{
    public interface IDynamic : IObject
    {
        void Update(GameTime gameTime);
        /* Below are collision responses */
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void TakeDamage();
    }
}
