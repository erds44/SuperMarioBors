using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.AudioFactory
{
    public static class SoundEffectFactory
    {
        private static ContentManager content;
        private static Dictionary<string, SoundEffect> soundDictionary;
        public static void Initialize(ContentManager inputContent)
        {
            content = inputContent;
        }
    }
}
