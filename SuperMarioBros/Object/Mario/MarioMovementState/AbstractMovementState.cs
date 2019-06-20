namespace SuperMarioBros.Marios.MarioMovementStates
{
    public abstract class AbstractMovementState
    {
        protected private IMario mario;
        public void MoveDown()
        {
            mario.MarioPhysics.MoveDown();
        }
        public void MoveLeft()
        {
            mario.MarioPhysics.MoveLeft();
        }
        public void MoveRight()
        {
            mario.MarioPhysics.MoveRight();
        }
    }
}
