using Microsoft.Xna.Framework;
using SuperMarioBros.Blocks.BlockStates;
using SuperMarioBros.Physicses;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks
{
    public class UsedBlock : AbstractBlock
    {
        public UsedBlock(Vector2 location)
        {
            HasItem = false;
            ObjState = ObjectState.Normal;
            Position = location;
            Physics = new Physics(Vector2.Zero, 0f, 0f);
            State = new BumpedState(this);
            Sprite = SpriteFactory.CreateSprite(GetType().Name);
        }
    }
}
