using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Interfaces.State;

namespace SuperMarioBros.Interfaces.Object
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
    }
}
