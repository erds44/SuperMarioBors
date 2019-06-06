using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBros.Objects;
using SuperMarioBros.Sprites;
using SuperMarioBros.Goombas.GoombaStates;
using SuperMarioBros.Object.Enemy;

namespace SuperMarioBros.Goombas
{
    public class Goomba : AbstractEnemy ,IEnemy
    {
        public Goomba( Vector2 location)
        {
            state = new LeftMovingEnemyState(this);
            this.location = location;
        }

    }
}
