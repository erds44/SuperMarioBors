using SuperMarioBros.Interfaces;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public interface IMarioMovementState : IUpdate
    {
        void Left();
        void Down();
        void Up();
        void Right();
        void Idle();
        void ChangeSprite(string type);
       // void Obstacle();
    }
}
