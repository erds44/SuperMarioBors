using Microsoft.Xna.Framework;
using SuperMarioBros.Classes.Objects.BlockObjects.BlockStates;

namespace SuperMarioBros.Classes.Objects.BlockObjects
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
