using Microsoft.Xna.Framework;
using SuperMarioBros.Goombas.GoombaStates;

namespace SuperMarioBros.Goombas
{
    public class StompedGoomba : AbstractEnemy
    {
        public StompedGoomba(Vector2 position)
        {
            State = new IdleEnemyState(this);
            Position = position;
        }
    }
}
