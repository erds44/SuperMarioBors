using Microsoft.Xna.Framework;

namespace SuperMarioBros.Blocks.BlockStates
{
    public interface IBlockState
    {
        void Used();
        void Bumped();
        void Broken();
        void Update(GameTime gameTime);
    }
}