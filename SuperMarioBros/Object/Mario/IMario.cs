using Microsoft.Xna.Framework;
using SuperMarioBros.Collisions;
using SuperMarioBros.Interfaces.State;
using SuperMarioBros.Marios.MarioMovementStates;
using SuperMarioBros.Objects;
using SuperMarioBros.Physicses;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Marios
{
    public interface IMario : IDynamic
    {
        double Timer { get; set; }
        double NoMovementTimer { get; set; }
        bool PowerFlag { get; set; }
        ISprite Sprite { get; set; }
        IMarioHealthState HealthState { get; set; }
        IMarioMovementState MovementState { get; set; }
        MarioPhysics MarioPhysics { get; }
        void Left();
        void Down();
        void Up();
        void Right();
        void Idle();
        new void Update(GameTime gameTime);
        IMario ReturnItself();
        void BumpUp();
        void RedMushroom();
        void OnFireFlower();
        void GreenMushroom();
        void Coin();
    }
}
