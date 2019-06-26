using Microsoft.Xna.Framework;

namespace SuperMarioBros.Blocks.BlockStates
{
    public class BumpedState : IBlockState
    {
        private readonly IBlock block;
        private Vector2 bumpPeak;
        private Vector2 offSet = new Vector2(0, -20);
        private Vector2 InitialVelocity = new Vector2(0, -150);

        public BumpedState(IBlock block)
        {
            this.block = block;
            block.Physics.Velocity = InitialVelocity;
            bumpPeak = block.Position + offSet;
        }

        public void Broken()
        {
            // Do Nothing
        }

        public void Bumped()
        {
            // Do Nothing
        }

        public void Update(GameTime gameTime)
        {
            block.Position += block.Physics.Displacement(gameTime);
            if (block.Position.Y <= bumpPeak.Y)
            {
                block.Physics.Velocity = -InitialVelocity;
            }
            else if (block.Position.Y >= bumpPeak.Y - offSet.Y)
            {
                block.Physics.Velocity = Vector2.Zero;
                block.State = new NormalState(block);
            }
        }

        public void Used()
        {
           // Do Nothing
        }
    }
}
