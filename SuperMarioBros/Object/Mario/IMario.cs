using Microsoft.Xna.Framework;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Objects.Mario.TransitionState;
using SuperMarioBros.Sprites;
using System;

namespace SuperMarioBros.Marios
{
    public interface IMario : IDynamic
    {
        event Action ClearingScoresEvent;
        event Action DeathEvent;
        event Action<Vector2> PowerUpEvent;
        event Action<Vector2> ExtraLifeEvent;
        int EnemyKillStreakCounter { get; set; }
        double NoMovementTimer { get; set; }
        bool OnGround { get; set; }
        bool PowerFlag { get; set; }
        bool KeyUpPower { get; set; }
        ISprite Sprite { get; set; }
        IMarioHealthState HealthState { get; set; }
        IMarioMovementState MovementState { get; set; }
        IMarioTransitionState TransitionState { get; set; }
        void Left();
        void Down();
        void Up();
        void Right();
        void Idle();
        new void Update(GameTime gameTime);
        void TakeFlower();
        void TakeRedMushroom();
        void TakeGreenMushroom();
        void TakeStar();
        void TakeDamage();
        void TimeOver();
        void SlidingFlagPole();
        void ChangeSlidingDirection();
    }
}
