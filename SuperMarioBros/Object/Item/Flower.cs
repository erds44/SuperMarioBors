using Microsoft.Xna.Framework;

namespace SuperMarioBros.Items
{
    public class Flower : AbstractItem , IItem
    {
        public Flower(Vector2 location)
        {
            Position = location;
            base.Initialize();
            collidableVelocity = Vector2.Zero;
        }
    
    }
}
