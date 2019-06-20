namespace SuperMarioBros.Marios.MarioMovementStates
{
    public interface IMarioMovementState
    {
        void Left();
        void Down();
        void Up();
        void Right();
        void Idle();
        /* below is collision responses */
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void Update();
        void BumpUp();
    }
}
