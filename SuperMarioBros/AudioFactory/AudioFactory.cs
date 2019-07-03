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
        private Dictionary<string, Song> songDictionary;
        private Dictionary<string, SoundEffect> soundDictionary;
        public static AudioFactory Instance { get; } = new AudioFactory();
        private AudioFactory(){}
        public void Initialize(ContentManager inputContent, string soundPath, string musicPath)
        {
            content = inputContent;
            var audioLoader = new AudioLoader(content, soundPath, musicPath);
            songDictionary = audioLoader.MusicInfo;
            soundDictionary = audioLoader.SoundInfo;
        }

        public Song CreateSong(string name)
        {
            if (songDictionary.TryGetValue(name, out Song song)) return song;
            Console.WriteLine("Cannot find song" + name);
            return null;
        }
        public SoundEffect CreateSound(string name)
        {
            if (soundDictionary.TryGetValue(name, out SoundEffect sound)) return sound;
            Console.WriteLine("Cannot find sound" + name);
            return null;
        }
    }
}
