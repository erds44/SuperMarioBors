using Microsoft.Xna.Framework;

namespace SuperMarioBros.Blocks
{
    public class BlueBrickBlock:AbstractBlock
    {
        private protected double deleteTimer = 0.1;
        private protected bool bumped;
        public BlueBrickBlock(Vector2 location)
        {
            ItemType = null;
            HasItem = false;
            Position = location;
            bumped = false;
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
        public override void Borken()
        {
            State.Bumped(); /* treat as bump to kill enemy if on top of it */
            Sprite = null;
            bumped = true;
            base.Borken();
        }
    }
}
