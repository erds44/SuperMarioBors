using Microsoft.Xna.Framework;
using SuperMarioBros.Class.Object.BlockObject.BlockState;

namespace SuperMarioBros.Class.Object.BlockObject
{
    public class RockBlockObject : BlockObject
    {
        public RockBlockObject( Vector2 location)
        {
            this.location = location;
            this.state = new RockBlockState(this);
        }
    }
}
