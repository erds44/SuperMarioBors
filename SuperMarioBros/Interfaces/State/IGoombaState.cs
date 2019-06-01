namespace SuperMarioBros.Interfaces.States
{
    public interface IGoombaState : IState
    {
        // void ChangeDirection(); Not used in current Senario
        void BeStomped();
        void BeFlipped();
    }
}
