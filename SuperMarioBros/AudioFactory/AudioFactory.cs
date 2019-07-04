using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.Loading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBros.AudioFactories
{
    public class AudioFactory
    {
        private ContentManager content;
        private Dictionary<string, string> songDictionary;
        private Dictionary<string, string> soundDictionary;
        public static AudioFactory Instance
        {
            get
            {
                if (instance is null) instance = new AudioFactory();
                return instance;
            }
        }
        private static AudioFactory instance;
        private AudioFactory(){}
        public void Initialize(ContentManager inputContent, string soundPath, string musicPath)
        {
            content = inputContent;
            var audioLoader = new AudioLoader(soundPath, musicPath);
            songDictionary = audioLoader.MusicInfo;
            soundDictionary = audioLoader.SoundInfo;
        }

        public Song CreateSong(string name)
        {
            if (songDictionary.TryGetValue(name, out string song)) return content.Load<Song>(song);
            Console.WriteLine("Cannot find song" + name);
            return null;
        }
        public SoundEffect CreateSound(string name)
        {
            if (soundDictionary.TryGetValue(name, out string sound)) return content.Load<SoundEffect>(sound);
            Console.WriteLine("Cannot find sound" + name);
            return null;
        }
    }
}
