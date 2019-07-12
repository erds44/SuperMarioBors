using Microsoft.Xna.Framework;
using SuperMarioBros.Utility;

namespace SuperMarioBros.Blocks
{
    public class BrickBlock : AbstractBlock 
    {
        /* Star, Bump, or Borken */
        private protected double deleteTimer = Timers.BrickBlockTimeSpan;
        private protected bool bumped;
        public BrickBlock(Vector2 location)
        {
            ItemType = null;
            HasItem = false;
            Position = location;
            bumped = false;
            CanBeBumped = true;
            base.Initialize();
        }

        public override void Bumped()
        {
            State.Bumped();
        }

        public override void Update(GameTime gameTime)
        {
            if (bumped)
            {
                deleteTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (deleteTimer <= 0) ObjState = ObjectState.Destroy;
            }
            State.Update(gameTime);
        }

        public override void Used()
        {
            State.Used();
        }
        public override void Broken()
        {
            State.Bumped(); /* treat as bump to kill enemy if on top of it */
            Sprite = null;
            bumped = true;
            base.Broken();
        }
    }
}
