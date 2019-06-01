using Microsoft.Xna.Framework;
using SuperMarioBros.Classes.Objects.BlockObjects.BlockStates;

namespace SuperMarioBros.Classes.Objects.BlockObjects
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
