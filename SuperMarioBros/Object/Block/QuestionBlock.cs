using Microsoft.Xna.Framework;
using SuperMarioBros.SpriteFactories;

namespace SuperMarioBros.Blocks
{
    public class QuestionBlock : AbstractBlock
    {
        public QuestionBlock(Point location)
        {
            this.location = location;
            sprite = SpriteFactory.CreateSprite(this.GetType().Name);
        }
    }
}
