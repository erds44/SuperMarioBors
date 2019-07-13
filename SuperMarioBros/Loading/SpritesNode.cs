using SuperMarioBros.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.Loading
{
    public class SpritesNode
    {
        public string ObjectName { get; set; }
        public string SpriteName { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int TotalFrame { get; set; }
        public int Delay { get; set; }

        public SpritesNode() { }

        public SpritesNode(string objectName, string spriteName)
        {
            this.ObjectName = objectName;
            this.SpriteName = spriteName;
            this.Width = SpriteConsts.DefaultWidth;
            this.Height = SpriteConsts.DefaultHeight;
            this.TotalFrame = SpriteConsts.DefaultTotalFrame;
            this.Delay = GeneralConstants.DefaultDelayScale;
        }

        public SpritesNode(string objectName,string spriteName,int width, int height, int totalFrame, int delay)
        {
            this.ObjectName = objectName;
            this.SpriteName = spriteName;
            this.Width = width;
            this.Height = height;
            this.TotalFrame = totalFrame;
            this.Delay = delay;
        }
    }
}
