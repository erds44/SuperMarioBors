using Microsoft.Xna.Framework;
using SuperMarioBros.Classes.Objects.BlockObjects.BlockStates;

namespace SuperMarioBros.Classes.Objects.BlockObjects
{
    public class HiddenBlockObject : BlockObject
    {
        public HiddenBlockObject( Vector2 location)
        {
            this.location = location;
            this.state = new HiddenBlockState(this);
        }
    }
}
