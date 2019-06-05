using SuperMarioBros.Objects;

namespace SuperMarioBros.Marios.MarioMovementStates
{
    public abstract class AbstractMovementState
    {
        protected private IMario mario;
        protected string type;
        protected private Physics marioPhysics;
        public void Obstacle()
        {
            marioPhysics.Undo();
        }

    }
}
