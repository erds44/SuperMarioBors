using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.AudioFactory
{
    public static class MusicFactory
    {
        private static ContentManager content;
        private static Dictionary<string, Song> songDictionary;
        public static void Initialize(ContentManager inputContent)
        {
            content = inputContent;
        }
    }
}
