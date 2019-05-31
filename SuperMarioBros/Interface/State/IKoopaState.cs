namespace SuperMarioBros.Interface.State
{
    interface IKoopaState : IState
    {
        // void ChangeDirection(); Not used in current Senario
        void BeStomped();
        void BeFlipped();
    }
}
