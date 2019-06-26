using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Loading
{
    public class SpritesNode
    {
        public string objectName;
        public string spriteName;
        public int width;
        public int height;
        public int totalFrame;
        public float delay;

        public SpritesNode()
        {

        }

        public SpritesNode(string objectName,string spriteName,int width=0, int height=0, int totalFrame = 1, float delay = 0)
        {
            this.objectName = objectName;
            this.spriteName = spriteName;
            this.width = width;
            this.height = height;
            this.totalFrame = totalFrame;
            this.delay = delay;
        }
    }
}
