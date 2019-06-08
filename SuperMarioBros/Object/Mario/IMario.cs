using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Marios
{
    public interface IMario : IObject, IMarioHealthState, IMarioMovementState
    {
        ISprite Sprite { get; set; }
        IMarioHealthState HealthState { get; set; }
        IMarioMovementState MovementState { get; set; }
        Physics MarioPhysics { get; }
        void Obstacle();
    }
}
