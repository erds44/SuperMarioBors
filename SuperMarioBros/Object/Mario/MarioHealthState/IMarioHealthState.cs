namespace SuperMarioBros.Interfaces.State
{
    public interface IMarioHealthState 
    {
        /* powerup always follows small-big-fire
           void PowerUp();
           For Sprint3, we assume RedMushroom and FireFlower can appear at the same time;
        */
        void TakeDamage();
        void RedMushroom();
        // gives error to use event if not start with On
        void OnFireFlower();
        void GreenMushroom();
        void Coin();
    }
}
