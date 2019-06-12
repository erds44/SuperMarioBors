using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Goombas;
using SuperMarioBros.Goombas.GoombaStates;
using SuperMarioBros.Objects.Enemy;
using SuperMarioBros.Sprites;

namespace SuperMarioBros.Koopas
{
    public class StompedKoopa : AbstractEnemy
    {
        public StompedKoopa(Point location)
        {
            this.location = location;
            state = new IdleEnemyState(this);
        }
    }
}
