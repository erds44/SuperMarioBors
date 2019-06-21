using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Loading
{
   public  class SpecialBlock
    {
        public String blockType;
        public Vector2 position;
        public int shape;
        public int size;
        public int width;
        public String itemType = "noType";
        public int itemCount = 0;

        public SpecialBlock()
        {

        }

        public SpecialBlock(String blockType, Vector2 position, int shape, int size, int width, String itemType, int itemCount)
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
