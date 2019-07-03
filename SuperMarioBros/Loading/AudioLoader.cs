using Microsoft.Xna.Framework.Audio;
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
        private readonly List<AudioNode> soundEffects = new List<AudioNode>
        {
            new AudioNode("1up", "Sounds/1up"),
            new AudioNode("bowserfall", "Sounds/bowserfall"),
            new AudioNode("bowserfire", "Sounds/bowserfire"),
            new AudioNode("breakblock", "Sounds/breakblock"),
            new AudioNode("bump", "Sounds/bump"),
            new AudioNode("coin", "Sounds/coin"),
            new AudioNode("fireball", "Sounds/fireball"),
            new AudioNode("fireworks", "Sounds/fireworks"),
            new AudioNode("flagpole", "Sounds/flagpole"),
            new AudioNode("gameover", "Sounds/gameover"),
            new AudioNode("jump", "Sounds/jump"),
            new AudioNode("jumpsuper", "Sounds/jumpsuper"),
            new AudioNode("kick", "Sounds/kick"),
            new AudioNode("mariodie", "Sounds/mariodie"),
            new AudioNode("pause", "Sounds/pause"),
            new AudioNode("pipe", "Sounds/pipe"),
            new AudioNode("powerup", "Sounds/powerup"),
            new AudioNode("powerupappears", "Sounds/powerupappears"),
            new AudioNode("stageclear", "Sounds/stageclear"),
            new AudioNode("stomp", "Sounds/stomp"),
            new AudioNode("vine", "Sounds/vine"),
            new AudioNode("warning", "Sounds/warning"),
            new AudioNode("worldclear", "Sounds/worldclear")
        };

        private readonly List<AudioNode> musics = new List<AudioNode>
        {
            new AudioNode("overworld", "Musics/overworld"),
            new AudioNode("underworld", "Musics/underworld"),
            new AudioNode("underwater", "Musics/underwater"),
            new AudioNode("castle", "Musics/castle"),
            new AudioNode("starman", "Musics/starman"),
            new AudioNode("levelcomplete", "Musics/levelcomplete"),
            new AudioNode("castlecomplete", "Musics/castlecomplete"),
            new AudioNode("youredead", "Musics/youredead"),
            new AudioNode("gameover", "Musics/gameover"),
            new AudioNode("gameover2", "Musics/gameover2"),
            new AudioNode("intoTheTunnel", "Musics/intoTheTunnel"),
            new AudioNode("ending", "Musics/ending"),
            new AudioNode("hurry", "Musics/hurry"),
            new AudioNode("hurryUnderground", "Musics/hurryUnderground"),
            new AudioNode("hurryUnderwater", "Musics/hurryUnderwater"),
            new AudioNode("hurryCastle", "Musics/hurryCastle"),
            new AudioNode("hurryStarman", "Musics/hurryStarman"),
            new AudioNode("hurryOverworld", "Musics/hurryOverworld"),
        };

        public AudioLoader(string soundPath, string musicPath)
        {
            XMLWriter("Sounds.xml", soundEffects);
            XMLWriter("Musics.xml", musics);
        }
    }
}
