using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Items;
using SuperMarioBros.Objects;

namespace SuperMarioBros.Stats
{
    public class TimeStats
    {
        private readonly float initalTime;
        public float currentTime { get; private set; }
        private int songUpdateDelay = 0;
        public TimeStats()
        {
            initalTime = 100;
            currentTime = initalTime;
        }
        public void Reset()
        {
            currentTime = initalTime;
        }
        public void Update(GameTime gameTime) 
        {
            currentTime -= 2 * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (++songUpdateDelay > 10 && currentTime <= 100)
            {
                songUpdateDelay = 0;
                Song hurrySong = AudioFactory.Instance.CreateHurrySong(MediaPlayer.Queue.ActiveSong, out bool shouldNotChange);
                if (!shouldNotChange) { MediaPlayer.Play(hurrySong); }
            }
        }
        public int TimeBonusScore()
        {
            if (currentTime <= 3)
            {
                currentTime = 0;
                ObjectFactory.Instance.CreateNonCollidableObject(typeof(WinFlag), new Vector2(8620, 410));
                return  (int)currentTime * 100; //100 score for each sec remain.
            }
            else
            {
                currentTime -= 3; //Use 3 as count unit.
                return 300; //100 score for each sec remain.
            }
        }
    }
}
