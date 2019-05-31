namespace SuperMarioBros.Interface
{
    public interface IReceiver
    {
        void Quit();
        void Left();
        void Right();
        void Up();
        void Down();
        void BigMario();
        void SmallMario();
        void FireMario();
        void DeadMario();
        void Reset();
        void QuestionBlockToUsedBlock();
        void HiddenBlockToUsedBlock();
        void BrickBlockDisappear();

    }
}
