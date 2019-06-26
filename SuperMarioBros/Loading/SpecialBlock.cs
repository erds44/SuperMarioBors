using Microsoft.Xna.Framework;
using System;

namespace SuperMarioBros.Loading
{
    public  class SpecialBlock
    {
        public string blockType;
        public Vector2 position;
        public int shape;
        public int size;
        public int width;
        public string itemType = "noType";
        public int itemCount = 0;

        public SpecialBlock()
        {

        }

        public SpecialBlock(string blockType, Vector2 position, int shape, int size, int width, string itemType, int itemCount)
        {
            this.blockType = blockType;
            this.position = position;
            this.shape = shape;
            this.size = size;
            this.width = width;
            this.itemType = itemType;
            this.itemCount = itemCount;
        }
    }
}
