using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class NormalState : IBlockState
    {
        private readonly IBlock block;

        public NormalState(IBlock block)
        {
            this.block = block;
            if (!(block is HiddenBlock))
                block.Sprite = SpriteFactory.CreateSprite(block.GetType().Name);
        }

        public void Broken()
        {
            block.Sprite = null;
            block.ObjState = ObjectState.Destroy;
        }

        public void Bumped()
        {
            block.State = new BumpedState(block);
        }

        public void Update(GameTime gameTime)
        {
            // Do Nothing
        }

        public void Used()
        {
            block.ObjState = ObjectState.Destroy;
        }
    }
}
