using Microsoft.Xna.Framework;
using System;

namespace SuperMarioBros.Blocks
{
    public class QuestionBlock : AbstractBlock
    {
        public QuestionBlock(Vector2 location, Type itemType)
        {
            this.ItemType = itemType;
            Position = location;
            base.Initialize();
        }
        public override void Bumped()
        {
            ObjState = ObjectState.Destroy;
        }
    }
}
