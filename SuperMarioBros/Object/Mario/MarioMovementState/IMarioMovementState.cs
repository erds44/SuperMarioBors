using SuperMarioBros.Collisions;
using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public interface IMarioMovementState
    {
        void Left();
        void Down();
        void Up();
        void Right();
        void Idle();
        void Obstacle(Direction direction);
    }
}
