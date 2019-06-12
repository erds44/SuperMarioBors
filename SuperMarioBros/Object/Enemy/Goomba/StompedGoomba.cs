using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas.GoombaStates;

namespace SuperMarioBros.Goombas
{
    public class StompedGoomba : AbstractEnemy
    {
        public StompedGoomba(Point position)
        {
            state = new IdleEnemyState(this);
            this.location = position;
        }


        public static void BeStomped()
        {
            // Do Nothing
        }

        public static void BeFlipped()
        {
            // Do Nothing
        }

    }
}
