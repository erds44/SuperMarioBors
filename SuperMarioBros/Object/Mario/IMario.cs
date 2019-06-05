using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Marios
{
    public interface IMario : IObject, IMarioState
    {
        void ChangeMarioState(IMarioState marioState);
        void ChangeMovementState(IMarioMovementState movementState);
        void ChangeSprite(ISprite sprite);
        void Up();
        void Down();
        void Left();
        void Right();
        void Idle();
        void Obstacle();
        void Coin();
    }
}
