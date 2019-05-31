namespace SuperMarioBros.Interface.State
{
    public interface IMarioState : IState
    {
        void Left();
        void Down();
        void Up();
        void Right();
        void ToSmall();
        void ToBig();
        void ToFire();
        void Fire();
        void Die();
    }
}
