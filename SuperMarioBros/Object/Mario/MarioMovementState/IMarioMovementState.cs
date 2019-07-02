using Microsoft.Xna.Framework;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public interface IMarioMovementState
    {
        void Left();
        void Down();
        void Up();
        void Right();
        void Idle();
        void Update(GameTime gameTime);
        void OnGround();
        void OnFireBall();
        void SlidingFlagPole();
        void ChangeSlidingDirection();
    }
}
