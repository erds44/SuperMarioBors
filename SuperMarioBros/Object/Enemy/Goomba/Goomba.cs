using Microsoft.Xna.Framework;
using SuperMarioBros.Objects.Enemy;

namespace SuperMarioBros.Goombas
{
    public class Goomba : AbstractEnemy
    {
        public Goomba( Point location)
        {
            State = new LeftMoving(this);
            this.location = location;
        }

    }
}
