using Microsoft.Xna.Framework;
using SuperMarioBros.Class.Object.BlockObject.BlockState;

namespace SuperMarioBros.Class.Object.BlockObject
{
    public class BrickBlockObject : BlockObject
    {
        public BrickBlockObject( Vector2 location)
        {
            this.location = location;
            this.state = new BrickBlockState(this);
            //Console.Out.WriteLine("BrickBlock created");
        }

    }
}
