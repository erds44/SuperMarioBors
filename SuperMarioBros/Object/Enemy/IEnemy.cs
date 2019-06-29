using Microsoft.Xna.Framework;
using SuperMarioBros.Sprites;
using System;

namespace SuperMarioBros.Objects.Enemy
{
    public interface IEnemy : IDynamic
    {
        event Action<Vector2> StompedEvent;
        IEnemyHealthState HealthState { get; set; }
        IEnemyMovementState MovementState { get; set; }
        ISprite Sprite { get; set; }
        void Flipped();
        void Stomped();
        void ChangeDirection(); 
        /* Change the direction of enemy, mainly used for koopa shell */
        void MoveLeft();
        void MoveRight();
    }
}
