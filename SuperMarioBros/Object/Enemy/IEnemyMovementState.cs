using Microsoft.Xna.Framework;

namespace SuperMarioBros.Objects.Enemy
{
    public interface IEnemyMovementState 
    {
        void ChangeDirection();
        void Stomped();
        void Update(GameTime gameTime);
        /* Change the direction of enemy, mainly used for koopa shell */
        void MoveLeft();
        void MoveRight();
    }
}
