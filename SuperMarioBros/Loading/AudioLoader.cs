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
        public Dictionary<string, Song> MusicInfo { get; }
        public Dictionary<string, SoundEffect> SoundInfo { get; }
        public AudioLoader(ContentManager inputContent, string soundPath, string musicPath)
        {
            sounds = XMLReader<AudioNode>(soundPath);
            SoundInfo = new Dictionary<string, SoundEffect>();
            foreach (AudioNode soundnode in sounds)
            {
                SoundEffect sound = inputContent.Load<SoundEffect>(soundnode.AudioName);
                SoundInfo.Add(soundnode.Name, sound);
            }
            musics = XMLReader<AudioNode>(musicPath);
            MusicInfo = new Dictionary<string, Song>();
            foreach (AudioNode musicnode in musics)
            {
                Song song = inputContent.Load<Song>(musicnode.AudioName);
                MusicInfo.Add(musicnode.Name, song);
            }
        }
    }
}
