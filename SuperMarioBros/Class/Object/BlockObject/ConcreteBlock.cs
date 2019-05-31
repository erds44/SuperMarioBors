using Microsoft.Xna.Framework;
using SuperMarioBros.Class.Object.BlockObject.BlockState;

namespace SuperMarioBros.Class.Object.BlockObject
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
