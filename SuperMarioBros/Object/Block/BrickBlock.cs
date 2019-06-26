using Microsoft.Xna.Framework;

namespace SuperMarioBros.Blocks
{
    public class BrickBlock : AbstractBlock 
    {
        /* Star, Bump, or Borken */
        public BrickBlock(Vector2 location)
        {
            ItemType = null;
            HasItem = false;
            Position = location;
            base.Initialize();
        }

        public override void Bumped()
        {
            State.Bumped();
        }

        public override void Update(GameTime gameTime)
        {
            State.Update(gameTime);
        }

        public override void Used()
        {
            State.Used();
        }
        public override void Borken()
        {
            State.Broken();
            base.Borken();
        }
    }
}
