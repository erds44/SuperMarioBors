using Microsoft.Xna.Framework;
using System;

namespace SuperMarioBros.Blocks
{
    public class HiddenBlock : AbstractBlock
    {
        public HiddenBlock(Vector2 location, Type type)
        {
            ItemType = type;
            HasItem = true;
            Position = location;
            base.Initialize();
        }
    }
}
