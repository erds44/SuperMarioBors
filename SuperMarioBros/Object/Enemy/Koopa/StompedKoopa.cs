using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas;
using SuperMarioBros.Goombas.GoombaStates;

namespace SuperMarioBros.Koopas
{
    public class StompedKoopa : AbstractEnemy
    {
        public StompedKoopa(Vector2 location)
        {
            Position = location;
            State = new IdleEnemyState(this);
        }
        //StompedKoopa will return to Koopa if not kicked


        public override void TakeDamage()
        {
            
        }
    }
}
