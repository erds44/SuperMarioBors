namespace SuperMarioBros.Marios.MarioMovementStates
{
    public abstract class AbstractMovementState
    {
        protected private IMario mario;
        public virtual void OnGround()
        {
            // Do Nothing
        }
        public virtual void Update()
        {
            //Do Nothing
        }
    }
}
