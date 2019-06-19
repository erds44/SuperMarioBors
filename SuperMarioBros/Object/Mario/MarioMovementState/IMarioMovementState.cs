namespace SuperMarioBros.Marios.MarioMovementStates
{
    public interface IMarioMovementState
    {
        void Left();
        void Down();
        void Up();
        void Right();
        void Idle();
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
        void Update();
    }
}
