using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using SuperMarioBros.AudioFactories;
using SuperMarioBros.Items;
using SuperMarioBros.Objects;
using static SuperMarioBros.Utility.GeneralConstants;
using static SuperMarioBros.Utility.Timers;
using static SuperMarioBros.Utility.Locations;

namespace SuperMarioBros.Stats
{
    public class TimeStats
    {
        private readonly float initalTime;
        public float currentTime { get; private set; }
        private int songUpdateDelay = InitialCount;
        public TimeStats()
        {
            initalTime = GameStartTime;
            currentTime = initalTime;
        }
        public void Reset()
        {
            currentTime = initalTime;
        }
        public void Update(GameTime gameTime) 
        {
            currentTime -= TimeElapseScale * (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (++songUpdateDelay > SongUpdateThreshold && currentTime <= HurryUpTime)
            {
                songUpdateDelay = InitialCount;
                Song hurrySong = AudioFactory.Instance.CreateHurrySong(MediaPlayer.Queue.ActiveSong, out bool shouldNotChange);
                if (!shouldNotChange) { MediaPlayer.Play(hurrySong); }
            }
        }
        public int TimeBonusScore()
        {
            if (currentTime <= TimeToScoreUnit)
            {
                currentTime = InitialTime;
                ObjectFactory.Instance.CreateNonCollidableObject(typeof(WinFlag), WinFlagPosition);
                return  (int)currentTime * TimeToScoreScale; //100 score for each sec remain.
            }
            else
            {
                currentTime -= TimeToScoreUnit; //Use 3 as count unit.
                return TimeToScoreScale*TimeToScoreUnit; //100 score for each sec remain.
            }
        }
    }
}
