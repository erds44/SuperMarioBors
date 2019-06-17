using Microsoft.Xna.Framework;
using SuperMarioBros.Objects.Enemy;

namespace SuperMarioBros.Goombas
{
    public class Goomba : AbstractEnemy
    {
        public Goomba( Vector2 location)
        {
            State = new LeftMoving(this);
            Position = location;
        }

    }
}
