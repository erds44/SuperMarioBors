using Microsoft.Xna.Framework;
using SuperMarioBros.Classes.Objects.BlockObjects.BlockStates;

namespace SuperMarioBros.Classes.Objects.BlockObjects
{
    public class ConcreteBlockObject : BlockObject
    {
        public ConcreteBlockObject( Vector2 location)
        {
            this.location = location;
            this.state = new ConcreteBlockState(this);
        }
    }
}
