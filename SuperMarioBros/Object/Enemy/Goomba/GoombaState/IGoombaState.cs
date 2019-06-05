using SuperMarioBros.Interfaces;

namespace SuperMarioBros.GoombaStates
{
    public interface IGoombaState
    {
        void ChangeDirection(); 
        void BeStomped();
        void BeFlipped();
    }
}
