using SuperMarioBros.Utility;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using static SuperMarioBros.Utility.XMLUtility;

namespace SuperMarioBros.Loading
{
    public class SpritesLoader
    {

        private List<SpritesNode> spritesList;

        public SpritesLoader() { }

        public Dictionary<string, SpritesNode> SpritesInfo()
        {
            Dictionary<string, SpritesNode> spritesInfo = new Dictionary<string, SpritesNode>();
            spritesList = XMLReader<SpritesNode>(StringConsts.SpritesFile);
            foreach (SpritesNode node in this.spritesList)
            {
                spritesInfo.Add(node.ObjectName, node);
            }
            return spritesInfo;
        }
    }
}
