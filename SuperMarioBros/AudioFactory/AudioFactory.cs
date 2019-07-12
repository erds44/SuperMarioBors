using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.Loading;
using System;
using System.Collections.Generic;

namespace SuperMarioBros.AudioFactories
{
    public class AudioFactory
    {
        private ContentManager content;
        private Dictionary<string, string> songDictionary;
        private Dictionary<string, string> soundDictionary;
        private Dictionary<string, string> hurryDictionary;
        public static AudioFactory Instance
        {
            get
            {
                if (instance is null) instance = new AudioFactory();
                return instance;
            }
        }
        private static AudioFactory instance;
        private AudioFactory() { }            
        public void Load(ContentManager inputContent, string soundPath, string musicPath, string hurryPath)
        {
            content = inputContent;
            var audioLoader = new AudioLoader(soundPath, musicPath, hurryPath);
            songDictionary = audioLoader.MusicInfo;
            soundDictionary = audioLoader.SoundInfo;
            hurryDictionary = audioLoader.HurryInfo;
        }


        public Song CreateSong(string name)
        {
            if (songDictionary.TryGetValue(name, out string song)) return content.Load<Song>(song);
            return null;
        }
        public Song CreateHurrySong(Song song, out bool isHurry)
        {
            string songName = song.Name;
            isHurry = true;
            bool foundHurry = hurryDictionary.TryGetValue(songName, out string hurry);
            if (!foundHurry) return song;
            isHurry = false;
            return content.Load<Song>(hurry);
        }
        public SoundEffect CreateSound(string name)
        {
            if (soundDictionary.TryGetValue(name, out string sound)) return content.Load<SoundEffect>(sound);
            Console.WriteLine("Cannot find sound" + name);
            return null;
        }
    }
}
