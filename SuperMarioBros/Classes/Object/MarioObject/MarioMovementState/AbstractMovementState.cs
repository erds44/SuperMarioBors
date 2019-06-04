using Microsoft.Xna.Framework;
using SuperMarioBros.Classes.Object;
using SuperMarioBros.Interfaces.Object;
using SuperMarioBros.Interfaces.State;

namespace SuperMarioBros.Classes.Objects.MarioObjects.MarioMovementState
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
