using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SuperMarioBros.Utilities.XMLUtility;

namespace SuperMarioBros.Loading
{
    public class AudioLoader
    {
        private readonly List<AudioNode> sounds;
        private readonly List<AudioNode> musics;
        public Dictionary<string, string> MusicInfo { get; }
        public Dictionary<string, string> SoundInfo { get; }
        public AudioLoader(string soundPath, string musicPath)
        {
            sounds = XMLReader<AudioNode>(soundPath);
            SoundInfo = new Dictionary<string, string>();
            foreach (AudioNode soundnode in sounds)
            {
                SoundInfo.Add(soundnode.Name, soundnode.AudioName);
            }
            musics = XMLReader<AudioNode>(musicPath);
            MusicInfo = new Dictionary<string, string>();
            foreach (AudioNode musicnode in musics)
            {
                MusicInfo.Add(musicnode.Name, musicnode.AudioName);
            }
        }
    }
}
