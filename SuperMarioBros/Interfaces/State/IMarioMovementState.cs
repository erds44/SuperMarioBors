using Microsoft.Xna.Framework;

namespace SuperMarioBros.Interfaces.State
{
    public interface IMarioMovementState : IState
    {
        void Left();
        void Down();
        void Up();
        void Right();
        void Idle();
        void ChangeSprite(string type);
    }
}
